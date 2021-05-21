using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using CSnet;
using SendMessageWinApp.MsgFormat;

namespace SendMessageWinApp.dataProcess
{
    class CAN_RawData
    {

    }
    class CAN_DataProcess
    {

        public delegate void EventHandler(string[] rawData);
        public event EventHandler ProcessRAW_Data;

        public delegate void DataEventHandler(MessageFormat cMf);
        public event DataEventHandler UpdateSysData;

        public int[] iSysData = new int[5];
        StringBuilder sb = new StringBuilder();
        public MessageFormat mf;

        public CAN_DataProcess()
        {
            mf = new MessageFormat();
            this.ProcessRAW_Data += this.OnProcessRAW_Data;
        }
        public void ProcessReceivedMsg(int iNumberOfMessages, byte[] message)
        {
            //Console.WriteLine("---------------- Process Msg ---------------");
            //Console.WriteLine("Num Msg = {0}", iNumberOfMessages);
            //Console.WriteLine(Encoding.ASCII.GetString(message));
            //Console.WriteLine("--------------------------------------------");
            icsSpyMessage[] stMsg = FromByteArray<icsSpyMessage>(message);

            int iBlock = 0;
            sb.Clear();
            for (int i = 0; i <= iNumberOfMessages; i++)
            {
                //Console.WriteLine("Byte 1 = " + icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data1)));
                if ((stMsg[i].StatusBitField & Convert.ToInt32(eDATA_STATUS_BITFIELD_1.SPY_STATUS_TX_MSG)) > 0)
                {
                    //Console.WriteLine("############### No Response from Device #################");
                    continue;
                }
                else
                {

                    if (stMsg[i].Protocol == (int)ePROTOCOL.SPY_PROTOCOL_CAN)
                    {
                        if (stMsg[i].Data1 == 0x80) // START PACKET
                        {
                            iBlock = 0;

                            //Console.WriteLine("Start Byte " + icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data1)));

                            //if (stMsg[i].NumberBytesData >= 1) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data1))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 2) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data2))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 3) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data3))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 4) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data4))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 5) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data5))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 6) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data6))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 7) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data7))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 8) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data8))).Append(" ");
                            iBlock++;
                        }
                        else if (stMsg[i].Data1 == (iBlock | 0xC0) && iBlock > 0) // END PACKET
                        {
                            //Console.WriteLine("End   Byte " + icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data1)));
                            if (stMsg[i].NumberBytesData >= 3) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data3))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 4) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data4))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 5) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data5))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 6) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data6))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 7) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data7))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 8) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data8))).Append(" ");
                            if (ValidateData(sb.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries)))
                            {
                                iBlock = 0;
                                Console.WriteLine("Correct Checksum Received");
                            }
                        }
                        else if (iBlock > 0) // MSG PACKET BETWEEN START AND END
                        {
                            //Console.WriteLine("Mid   Byte " + icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data1)));
                            if (stMsg[i].NumberBytesData >= 3) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data3))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 4) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data4))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 5) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data5))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 6) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data6))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 7) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data7))).Append(" ");
                            if (stMsg[i].NumberBytesData >= 8) sb.Append(icsNeoDll.ConvertToHex(Convert.ToString(stMsg[i].Data8))).Append(" ");
                            iBlock++;
                        }
                    }
                }
            }
            Console.WriteLine("Data : " + sb.ToString());
            sb.Clear();
        }

        private bool ValidateData(string[] bMsg)
        {
            if (bMsg.Length < 2) return false;
            byte Checksum = 0;
            int iCount = bMsg.Length - 1;

            //if ((1 + iCount) > bMsg.Length) return false;
            if (iCount != Convert.ToByte(bMsg[1], 16))
            {
                Console.WriteLine("Data length mismatch");
                return false;
            }
            for (int i = 1; i <= iCount - 1; i++)
            {
                //Console.WriteLine("Inside For loop " + bMsg[i]);
                Checksum ^= Convert.ToByte(bMsg[i], 16);
            }
            Checksum ^= 0xAA;
            if (Checksum == Convert.ToByte(bMsg[iCount], 16))
            {
                Console.WriteLine("Checksum = {0}", Checksum);
                ProcessRAW_Data(bMsg);
                return true;
            }
            return false;
        }

        public void OnProcessRAW_Data(string[] rawData)
        {

            //Console.WriteLine("Respone CMD ID is "+ icsNeoDll.ConvertToHex(rawData[2]));

            byte resp = Convert.ToByte(rawData[2], 16);
            byte normalresp = Convert.ToByte(rawData[3], 16);
            Console.WriteLine("resp:" + resp);
            Array.Clear(iSysData, 0, 5);
            if (resp == 0xA5)
            {

                String Sending_Unit_Address = rawData[0];
                GlobalFunctions.Sending_Unit_Address_X = Convert.ToString(Sending_Unit_Address[0]);
                GlobalFunctions.Sending_Unit_Address_Y = Convert.ToString(Sending_Unit_Address[1]);
                GlobalFunctions.EdgeDeviceStatus = true;
                Console.WriteLine("Sending_Unit_Address_X:" + GlobalFunctions.Sending_Unit_Address_X + "Sending_Unit_Address_Y:" + GlobalFunctions.Sending_Unit_Address_Y);
                // System State
                byte sysState = Convert.ToByte(rawData[7], 16);
                GlobalFunctions.System_State = sysState;

                if (sysState == (byte)ESystemState.FAULTSTATE) mf.sSysState = "FAULT";
                if (sysState == (byte)ESystemState.RESETSTATE) mf.sSysState = "RESET";
                if (sysState == (byte)ESystemState.STANDBYSTATE) mf.sSysState = "STANDBY";
                if (sysState == (byte)ESystemState.WAIT2_LAMPONSTATE) mf.sSysState = "WAIT2_LAMPON";
                if (sysState == (byte)ESystemState.LAMPONSTATE) mf.sSysState = "LAMPON";

                //Parse Fault Code
                string strFault = rawData[9] + rawData[8];
                mf.iFaultCode = Int32.Parse(strFault, System.Globalization.NumberStyles.HexNumber);

                // Parse PowerLevel
                iSysData[0] = Convert.ToByte(rawData[6], 16);
                GlobalFunctions.GblPowerLevel = Convert.ToString(rawData[6]);
                Console.WriteLine("PowerLevel is {0}", iSysData[0]);

                //Parse MagA Current
                string strMagA = rawData[23] + rawData[22];
                iSysData[1] = Int32.Parse(strMagA, System.Globalization.NumberStyles.HexNumber);
                Console.WriteLine("MagA = {0}", iSysData[1]);

                //Parse MagB Current
                string strMagB = rawData[25] + rawData[24];
                iSysData[2] = Int32.Parse(strMagB, System.Globalization.NumberStyles.HexNumber);
                Console.WriteLine("MagB = {0}", iSysData[2]);

                //Parse FilA Volt Current
                double dTemp;
                string strFilA = rawData[35] + rawData[34];
                dTemp = Int32.Parse(strFilA, System.Globalization.NumberStyles.HexNumber);
                dTemp *= 0.1;
                iSysData[3] = Convert.ToInt32(dTemp);
                Console.WriteLine("FilA Volt = {0}", iSysData[3]);

                //Parse AirPressure Current
                string strAirPressure = rawData[40] + rawData[41];
                dTemp = Int32.Parse(strAirPressure, System.Globalization.NumberStyles.HexNumber);
                dTemp *= 0.001;
                iSysData[4] = Convert.ToInt32(dTemp);
                Console.WriteLine("Air Pressure = {0}", iSysData[4]);

                mf.iSysData = iSysData;
                UpdateSysData(mf);

            }
            else if(normalresp== 0xCC)
            {
                // System State
                byte sysState = Convert.ToByte(rawData[17], 16);


                if (sysState == (byte)ESystemState.FAULTSTATE) mf.sSysState = "FAULT";
                if (sysState == (byte)ESystemState.RESETSTATE) mf.sSysState = "RESET";
                if (sysState == (byte)ESystemState.STANDBYSTATE) mf.sSysState = "STANDBY";
                if (sysState == (byte)ESystemState.WAIT2_LAMPONSTATE) mf.sSysState = "WAIT2_LAMPON";
                if (sysState == (byte)ESystemState.LAMPONSTATE) mf.sSysState = "LAMPON";

                //Parse Fault Code
                string strFault = rawData[6] + rawData[5];
                mf.iFaultCode = Int32.Parse(strFault, System.Globalization.NumberStyles.HexNumber);

                // Parse PowerLevel
                iSysData[0] = Convert.ToByte(rawData[4], 16);
                Console.WriteLine("PowerLevel is {0}", iSysData[0]);

                //Parse MagA Current
                string strMagA = rawData[21] + rawData[20];
                iSysData[1] = Int32.Parse(strMagA, System.Globalization.NumberStyles.HexNumber);
                Console.WriteLine("MagA = {0}", iSysData[1]);

                //Parse MagB Current
                string strMagB = rawData[23] + rawData[22];
                iSysData[2] = Int32.Parse(strMagB, System.Globalization.NumberStyles.HexNumber);
                Console.WriteLine("MagB = {0}", iSysData[2]);

                //Parse FilA Volt Current
                double dTemp;
                string strFilA = rawData[33] + rawData[32];
                dTemp = Int32.Parse(strFilA, System.Globalization.NumberStyles.HexNumber);
                dTemp *= 0.1;
                iSysData[3] = Convert.ToInt32(dTemp);
                Console.WriteLine("FilA Volt = {0}", iSysData[3]);

                //Parse AirPressure Current
                string strAirPressure = rawData[39] + rawData[38];
                dTemp = Int32.Parse(strAirPressure, System.Globalization.NumberStyles.HexNumber);
                dTemp *= 0.001;
                iSysData[4] = Convert.ToInt32(dTemp);
                Console.WriteLine("Air Pressure = {0}", iSysData[4]);

                mf.iSysData = iSysData;
                UpdateSysData(mf);
            }
            else
            {
                GlobalFunctions.EdgeDeviceStatus = false;
            }
        }

        private static T[] FromByteArray<T>(byte[] source) where T : struct
        {
            T[] destination = new T[source.Length / Marshal.SizeOf(typeof(T))];
            GCHandle handle = GCHandle.Alloc(destination, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Marshal.Copy(source, 0, pointer, source.Length);
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
