using System;
using System.Collections;
using System.Text;
using SendMessageWinApp;
using SendMessageWinApp.View;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using CSnet;


namespace SendMessageWinApp.canCom
{
    
    static class Constants
    {
        
        public const int RX_Timeout = 240;
        public const int DAQ_Interval = 250;
    }
    class CAN_TX_MSG
    {
        
        public Int32 lArbId = 0;
        public byte iNumBytes = 0;
        public Byte[] bData = new byte[8];

        public CAN_TX_MSG(Int32 arbId, byte numBytes, Byte[] data)
        {
            lArbId = arbId;
            iNumBytes = numBytes;
            for(int i=0; i<8; i++)
            {
                bData[i] = data[i];
            }   
        }

        public CAN_TX_MSG(CAN_TX_MSG obj)
        {
            this.lArbId = obj.lArbId;
            this.iNumBytes = obj.iNumBytes;
            for (int i = 0; i < 8; i++)
            {
                bData[i] = obj.bData[i];
            }
        }
    }
    
    class CAN_Connection
    {
        
        public delegate void MsgHandler(int iNumMsg, byte[] CAN_Msg);
        public event MsgHandler ProcessReceivedMsg;
        
        
        private static Mutex mutex = new Mutex();
        private static Queue<CAN_TX_MSG> qTxMsg = new Queue<CAN_TX_MSG>();
        private readonly IAzureIotView view;
        private int MaxDevice = 15;
        IntPtr m_hObject;
        NeoDevice[] ndNeoDevice;
        NeoDevice ndNeoToOpen;
        bool m_bPortOpen;
        int iNumberOfDevices;
        int iNumberOfMessages;
        int iNumberOfErrors;
        bool bStopBroadcast = false;
        byte[] bNetwork = new byte[255];
        int iOpenDeviceType;
        static icsSpyMessage[] stMessages = new icsSpyMessage[500];
        Stopwatch timeDelay = new Stopwatch();
        Stopwatch tCANWait = new Stopwatch();
        private int iElapsed = 0;

        private bool bStartDaq;
        public bool StartDAQ
        {
            get { return bStartDaq;  }
            set { bStartDaq = value;  }
        }

        public bool Stop3FABroadcast { 
            get { return bStopBroadcast; }
            set { bStopBroadcast = value; }
        }
        public CAN_Connection(IAzureIotView view)
        {
            
            this.view = view;
            ndNeoDevice = new NeoDevice[MaxDevice];
            //this.ProcessReceivedMsg += this.OnProcessReceivedMsg;
        }

        ~CAN_Connection()
        {
            view.PublishMessageText = " Closing Connection";
            int iResult;
            int iNumberOfErrors = 0;

            //close the port
            iResult = icsNeoDll.icsneoClosePort(m_hObject, ref iNumberOfErrors);
            if (iResult == 1)
            {
                view.PublishMessageText = "Port Closed OK!";
            }
            else
            {
                view.PublishMessageText = "Problem ClosingPort";
            }


            //Clear device type and open flag
            iOpenDeviceType = 0;
            m_bPortOpen = false;
        }

        public void scanDevice()
        {
            view.PublishMessageText = "Scanning for ValueCAN devices";
            view.ClearDevListBox();
            Array.Clear(ndNeoDevice, 0, ndNeoDevice.Length);
            int iResult;
            int iCount; 
            uint lDevTypes; //Holds the device types to look for
            lDevTypes = Convert.ToUInt32(eHardwareTypes.NEODEVICE_ALL);
            iNumberOfDevices = MaxDevice;

            //File NetworkID array
            for (iCount = 0; iCount < 255; iCount++)
            {
                bNetwork[iCount] = Convert.ToByte(iCount);
            }

            //Search for connected hardware
            iResult = icsNeoDll.icsneoFindNeoDevices(lDevTypes, ref ndNeoDevice[0], ref iNumberOfDevices);
            if (iResult == 0)
            {
                MessageBox.Show("Problem finding devices");
                view.PublishMessageText = "No ValueCAN device detected in the system";
                return;
            }
            else
            {
                view.PublishMessageText = Convert.ToString(iNumberOfDevices) +  " ValueCAN device detected in the system";
            }

            for (int i = 0; i < iNumberOfDevices; i++)
            {
                view.DeviceListBox = Convert.ToString(ndNeoDevice[i].SerialNumber);
            }
        }

        public void connectDevice()
        {
            int devSerial = Convert.ToInt32(view.DeviceListBox);
            for (int i = 0; i < iNumberOfDevices; i++)
            {
                if (ndNeoDevice[i].SerialNumber == devSerial)
                {
                    view.PublishMessageText = "Selected Device is " + Convert.ToString(devSerial);
                    ndNeoToOpen = ndNeoDevice[i];
                    //Open the selecteddevice
                    if (ndNeoToOpen.DeviceType == (int)eHardwareTypes.NEODEVICE_VCAN3)
                    {
                        int iResult = icsNeoDll.icsneoOpenNeoDevice(ref ndNeoToOpen, ref m_hObject, ref bNetwork[0], 1, 0);
                        if (iResult == 1)
                        {
                            m_bPortOpen = true;
                            GlobalFunctions.ValueCANStatus = true;
                            view.PublishMessageText = "ValueCAN3 with Serial Number " + Convert.ToString(devSerial) + " is connected";
                            

                        }
                        else
                        {
                            m_bPortOpen = false;
                            GlobalFunctions.ValueCANStatus = false;
                            MessageBox.Show("Problem Opening CAN device");
                            return;
                        }
                        //Set the device type 
                        iOpenDeviceType = ndNeoToOpen.DeviceType;
                    }
                    else
                    {
                        view.PublishMessageText = "Selected Device Type is not ValueCAN3";
                        MessageBox.Show("Selected Device Type is not ValueCAN3");
                    }
                }
            }
        }

        public void fnStartDaq()
        {
            if (!StartDAQ)
            {
                Stop3FABroadcast = false;
                var tdev = Task.Run(async () => await Send_3FA_cmd());
                var tGetDevInfo = Task.Run(async () => await GetMessageFromCAN());
                StartDAQ = true;
                view.PublishMessageText = "Data Acquisition Started";
            }
        }

        public void fnStopDaq()
        {
            if (StartDAQ)
            {
                Stop3FABroadcast = true;
                StartDAQ = false;
                Thread.Sleep(500);
                view.PublishMessageText = "Data Acquisition Stopped";
            }
        }

        public async Task GetMessageFromCAN()
        {
            long lResult = 0;
            icsSpyMessage stMessagesTx = new icsSpyMessage();
            long lNetworkID;
            int uiTimeout = 0;

            // Has the uset open neoVI yet?;
            if (m_bPortOpen == false)
            {
                MessageBox.Show("ValueCAN not connected");
                return; // do not read messages if we haven't opened neoVI yet
            }

            // Read the Network we will transmit on (indicated by lstNetwork ListBox)
            lNetworkID = (int)eNETWORK_ID.NETID_HSCAN;
            stMessagesTx.StatusBitField = 0;
            tCANWait.Start();
            timeDelay.Start();
            
            while (StartDAQ)
            {
                mutex.WaitOne(250);
                var txMsgCount = qTxMsg.Count;
                CAN_TX_MSG txMsg = null;
                Console.WriteLine("TX Msg count = {0}", txMsgCount);
                if(txMsgCount > 0)
                {
                    txMsg = qTxMsg.Dequeue();
                }
                mutex.ReleaseMutex();


                if ((txMsgCount > 0) && (txMsg != null))
                {
                    stMessagesTx.ArbIDOrHeader = txMsg.lArbId;            // The ArbID
                    stMessagesTx.NumberBytesData = txMsg.iNumBytes;         // The number of Data Bytes

                    stMessagesTx.Data1 = txMsg.bData[0];
                    stMessagesTx.Data2 = txMsg.bData[1];
                    stMessagesTx.Data3 = txMsg.bData[2];
                    stMessagesTx.Data4 = txMsg.bData[3];
                    stMessagesTx.Data5 = txMsg.bData[4];
                    stMessagesTx.Data6 = txMsg.bData[5];
                    stMessagesTx.Data7 = txMsg.bData[6];
                    stMessagesTx.Data8 = txMsg.bData[7];
                    Console.WriteLine("Sending TX MSG: ARB ID = " + icsNeoDll.ConvertToHex(Convert.ToString(txMsg.lArbId)) + " Data : " + BitConverter.ToString(txMsg.bData));
                    // Transmit the assembled message
                    lResult = icsNeoDll.icsneoTxMessages(m_hObject, ref stMessagesTx, (int)lNetworkID, 1);
                    if (lResult != 1)
                    {
                        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!! Problem Transmitting Message");
                        await Task.Delay(2000);
                        continue;
                    }
                    timeDelay.Restart();
                }
                else
                {
                    Console.WriteLine("No TX MSG in Queue");
                }

                if (lResult == 1 && iNumberOfMessages > 0) 
                {
                    // send the collected raw data bytes for processing
                    //ProcessReceivedMsg(Encoding.ASCII.GetBytes(sMsgData));
                    //Console.WriteLine("Num of Msg = {0}", iNumberOfMessages);
                    ProcessReceivedMsg(iNumberOfMessages, ToByteArray(stMessages));

                    Array.Clear(stMessages, 0, stMessages.Length);
                    iNumberOfMessages = -1;
                    lResult = 0;
                }

                uiTimeout = 0;
                iElapsed = Convert.ToInt32(timeDelay.Elapsed.TotalMilliseconds);
                if (iElapsed < Constants.RX_Timeout)
                    uiTimeout = Constants.RX_Timeout - iElapsed;
                else if(iElapsed < Constants.DAQ_Interval)
                    uiTimeout = Constants.DAQ_Interval - iElapsed;

                tCANWait.Restart();
                //Console.WriteLine("Ui Timeout before if {0}", uiTimeout);
                if (uiTimeout > 0)
                {

                    //Console.WriteLine("UI Timeout = {0}", uiTimeout);
                    if (icsNeoDll.icsneoWaitForRxMessagesWithTimeOut(m_hObject, Convert.ToUInt32(uiTimeout)) == 1)
                    {
                        // Message reveived success
                        if(tCANWait.Elapsed.TotalMilliseconds < uiTimeout)
                        {
                            //Console.WriteLine("########### Waiting for Timeout");
                            await Task.Delay((uiTimeout - Convert.ToInt32(tCANWait.Elapsed.TotalMilliseconds)));
                        }
                        Console.WriteLine("####### Message Received:: Time taken : {0} ########", timeDelay.Elapsed.TotalMilliseconds);
                    }
                    lResult = icsNeoDll.icsneoGetMessages(m_hObject, ref stMessages[0], ref iNumberOfMessages, ref iNumberOfErrors);
                }

                iElapsed = Convert.ToInt32(timeDelay.Elapsed.TotalMilliseconds);
                if (iElapsed < Constants.DAQ_Interval)
                {
                    //Console.WriteLine("Task Delay time = {0}", (Constants.DAQ_Interval - iElapsed));
                    await Task.Delay((Constants.DAQ_Interval - iElapsed));
                }
                //Console.WriteLine("End iElapsed = {0}", iElapsed);
            }
        }

        public static void AddBroadCastMsg(Int32 iArbId, byte iNumByte, byte[] bData)
        {
            CAN_TX_MSG txMsg = new CAN_TX_MSG(iArbId, iNumByte, bData);
            CAN_Connection.Add_TX_Msg(txMsg);
        }

        public static void Add_TX_Msg(CAN_TX_MSG objTxMsg)
        {
            mutex.WaitOne();
            if(qTxMsg.Count == 0)
                qTxMsg.Enqueue(objTxMsg);
            mutex.ReleaseMutex();

        }

        public async Task Send_3FA_cmd()
        {
           
            while (!Stop3FABroadcast) {
                Int32 iArbId;
                byte iNumByte;
              
                if (GlobalFunctions.System_Normal_Mode == false)
                {
                    iArbId = 0x3FA;
                    iNumByte = 6;
                    var bData = new byte[8] { 0x00, 0xE0, 0x04, 0xA5, 0x00, 0x00, 0x00, 0x00 };
                    byte Checksum = 0;
                    for (int i = 0; i <= bData.Length - 1; i++)
                    {
                        if (i > 1)
                        {
                            Checksum ^= bData[i];
                        }
                    }
                    Checksum ^= 0xAA;
                    bData[5] = Checksum;
                    CAN_Connection.AddBroadCastMsg(iArbId, iNumByte, bData);
                }
                else
                {
                    Console.WriteLine("System State:" + GlobalFunctions.System_State);
                    if (GlobalFunctions.System_State == 3)
                    {
                        //iArbId = 0x011;
                       
                        iArbId = Convert.ToByte(String.Format("0x0{0}{1}",GlobalFunctions.Sending_Unit_Address_X,GlobalFunctions.Sending_Unit_Address_Y), 16);
                        Console.WriteLine("iArbId:" + iArbId);
                        iNumByte = 7;
                        
                        var bData = new byte[8] { 0x00, Convert.ToByte(String.Format("0x{0}0",GlobalFunctions.Sending_Unit_Address_X),16), 0x05, 0x01, 0xCC, Convert.ToByte(String.Format("0x{0}", GlobalFunctions.GblPowerLevel), 16), 0x00, 0x00 };
                        byte Checksum = 0;
                        for (int i = 0; i <= bData.Length -1; i++)
                        {
                            if(i > 1)
                            {
                                Checksum ^= bData[i];
                            }
                        }
                        Checksum ^= 0xAA;
                        bData[6] = Checksum;
                        CAN_Connection.AddBroadCastMsg(iArbId, iNumByte, bData);
                    }
                    else if (GlobalFunctions.System_State == 6)
                    {
                        iArbId = Convert.ToByte(String.Format("0x0{0}{1}", GlobalFunctions.Sending_Unit_Address_X, GlobalFunctions.Sending_Unit_Address_Y), 16);
                        iNumByte = 7;
                        var bData = new byte[8] { 0x00, Convert.ToByte(String.Format("0x{0}0", GlobalFunctions.Sending_Unit_Address_X), 16), 0x05, 0x02, 0xCC, Convert.ToByte(String.Format("0x{0}", GlobalFunctions.GblPowerLevel), 16), 0x00, 0x00 };
                        byte Checksum = 0;
                        for (int i = 0; i <= bData.Length - 1; i++)
                        {
                            if (i > 1)
                            {
                                Checksum ^= bData[i];
                            }
                        }
                        Checksum ^= 0xAA;
                        bData[6] = Checksum;
                        CAN_Connection.AddBroadCastMsg(iArbId, iNumByte, bData);
                    }
                    else if (GlobalFunctions.System_State == 10)
                    {
                        iArbId = Convert.ToByte(String.Format("0x0{0}{1}", GlobalFunctions.Sending_Unit_Address_X, GlobalFunctions.Sending_Unit_Address_Y), 16);
                        iNumByte = 7;
                        var bData = new byte[8] { 0x00, Convert.ToByte(String.Format("0x{0}0", GlobalFunctions.Sending_Unit_Address_X), 16), 0x05, 0x04, 0xCC, Convert.ToByte(String.Format("0x{0}", GlobalFunctions.GblPowerLevel), 16), 0x00, 0x00 };
                        byte Checksum = 0;
                        for (int i = 0; i <= bData.Length - 1; i++)
                        {
                            if (i > 1)
                            {
                                Checksum ^= bData[i];
                            }
                        }
                        Checksum ^= 0xAA;
                        bData[6] = Checksum;
                        CAN_Connection.AddBroadCastMsg(iArbId, iNumByte, bData);
                    }
                    else
                    {
                        iArbId = Convert.ToByte(String.Format("0x0{0}{1}", GlobalFunctions.Sending_Unit_Address_X, GlobalFunctions.Sending_Unit_Address_Y), 16);
                        iNumByte = 7;
                        var bData = new byte[8] { 0x00, Convert.ToByte(String.Format("0x{0}0", GlobalFunctions.Sending_Unit_Address_X), 16), 0x05, 0x01, 0xCC, Convert.ToByte(String.Format("0x{0}", GlobalFunctions.GblPowerLevel), 16), 0x00, 0x00 };
                        byte Checksum = 0;
                        for (int i = 0; i <= bData.Length - 1; i++)
                        {
                            if (i > 1)
                            {
                                Checksum ^= bData[i];
                            }
                        }
                        Checksum ^= 0xAA;
                        bData[6] = Checksum;
                        CAN_Connection.AddBroadCastMsg(iArbId, iNumByte, bData);

                    }

                }
                
                await Task.Delay(250);
            }
        }

        private static byte[] ToByteArray<T>(T[] source) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(source, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                byte[] destination = new byte[source.Length * Marshal.SizeOf(typeof(T))];
                Marshal.Copy(pointer, destination, 0, destination.Length);
                return destination;
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }
    }
}
