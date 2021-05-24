using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendMessageWinApp.Publisher;
using SendMessageWinApp.View;
using SendMessageWinApp.canCom;
using SendMessageWinApp.dataProcess;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Data.SqlClient;
using System.Globalization;
using CSnet;
using LBSoft.IndustrialCtrls;

namespace SendMessageWinApp
{
    public partial class Form1 : Form, IAzureIotView
    {
        private delegate void UpdateConnectLabelDelegate(string message);
        private delegate void UpdateConnectStringTextDelegate(string message);

        private delegate void UpdateDeviceIdTextDelegate(string message);
        private delegate void UpdatePowerLevelTextDelegate(string message);
        private delegate void UpdateMagACurrentTextDelegate(string message);
        private delegate void UpdateMagBCurrentTextDelegate(string message);
        private delegate void UpdateFilAVoltTextDelegate(string message);
        private delegate void UpdateAirPressureTextDelegate(string message);

        private delegate void UpdateMessageTextDelegate(string message);
        private delegate void UpdateDeviceSerialNumberDelegate(string message);

        private cMessagePublisher azureIotPub;
        private CAN_Connection objCanCom;
        private CAN_DataProcess objCanPrcs;
        private bool IsBlink = true;
        private bool bBlink = false;
        System.Threading.Timer TimerBlink = null;
        public SqlConnection dbConn;
        public Form1()
        {
            AllocConsole();
            InitializeComponent();
            GlobalFunctions.Intialization();
            StartBtn.Enabled = false;
            StopBtn.Enabled = false;
            objCanCom = new CAN_Connection(this);
            objCanPrcs = new CAN_DataProcess();
            objCanCom.ProcessReceivedMsg += objCanPrcs.ProcessReceivedMsg;
            //     TimerBlink = new System.Threading.Timer(BlinkLEDImage, null, 700 , 700);

        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        private async void ConnectBtn_click(object sender, EventArgs e)
        {

            azureIotPub = new cMessagePublisher(this);
            objCanPrcs.UpdateSysData += azureIotPub.UpdateSystemData;
            Console.WriteLine("Azure connect clicked");
            bool status = await azureIotPub.ConnectToAzure(connectionStrTextBox.Text);
            Console.WriteLine("Status :  " + status.ToString());
            if (status)
            {
                StartBtn.Enabled = true;
                ConnectStatusLabel = "Connected";
                UpdateMessageText("Succesfully connected to Azure IoT");
            }
            else
            {
                StartBtn.Enabled = false;
                StopBtn.Enabled = false;
                ConnectStatusLabel = "Connection Failed";
                UpdateMessageText("Failed to connect Azure IoT");

            }
            //string sDbLocalPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            //string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='" + sDbLocalPath + @"PublisherConfig.mdf'" + ";Integrated Security = True;";
            //UpdateMessageText("DB String : " + connStr);
            //dbConn = new SqlConnection(connStr);
            //dbConn.Open();
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            StopBtn.Enabled = true;
            StartBtn.Enabled = false;
            objCanCom.fnStartDaq();
            await azureIotPub.startPublishData();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            azureIotPub.stopPublishData();
            StopBtn.Enabled = false;
            StartBtn.Enabled = true;
            objCanCom.fnStopDaq();
            GlobalFunctions.EdgeDeviceStatus = false;
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            azureIotPub.Disconnect();
            StartBtn.Enabled = false;
            StopBtn.Enabled = false;
            //dbConn.Close();
        }

        public string ConnectStatusLabel
        {
            get
            {
                return StatusLbl.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    StatusLbl.Invoke(new UpdateConnectLabelDelegate(UpdateConnectLabel), value);
                }
                else
                {
                    StatusLbl.Text = value;
                    if (value == "Connected")
                        StatusLbl.ForeColor = Color.Green;
                    else if (value == "Valid Connection String")
                        StatusLbl.ForeColor = Color.Green;
                    else
                        StatusLbl.ForeColor = Color.Red;
                }
            }
        }

        private void UpdateConnectLabel(string message)
        {
            StatusLbl.Text = message;
        }


        public string ConnectionStringTextBox
        {
            get
            {
                return StatusLbl.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    StatusLbl.Invoke(new UpdateConnectStringTextDelegate(UpdateConnectStringText), value);
                }
                else
                {
                    StatusLbl.Text = value;
                }
            }
        }

        private void UpdateConnectStringText(string message)
        {
            connectionStrTextBox.Text = message;
        }

        public string PowerLevel
        {
            get
            {
                return powerLvlTxtBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    powerLvlTxtBox.Invoke(new UpdatePowerLevelTextDelegate(UpdatePowerLvlText), value);
                }
                else
                {
                    powerLvlTxtBox.Text = value;
                }
            }
        }

        private void UpdatePowerLvlText(string message)
        {
            powerLvlTxtBox.Text = message;
        }

        public string MagATemp
        {
            get
            {
                return MagATxtBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    MagATxtBox.Invoke(new UpdateMagACurrentTextDelegate(UpdateMagAText), value);
                }
                else
                {
                    MagATxtBox.Text = value;
                }
            }
        }

        private void UpdateMagAText(string message)
        {
            MagATxtBox.Text = message;
        }

        public string MagBTemp
        {
            get
            {
                return MagBTextBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    MagBTextBox.Invoke(new UpdateMagBCurrentTextDelegate(UpdateMagBText), value);
                }
                else
                {
                    MagBTextBox.Text = value;
                }
            }
        }

        private void UpdateMagBText(string message)
        {
            MagBTextBox.Text = message;
        }

        public string FilA_Volt
        {
            get
            {
                return filATxtBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    filATxtBox.Invoke(new UpdateFilAVoltTextDelegate(UpdateFilAText), value);
                }
                else
                {
                    filATxtBox.Text = value;
                }
            }
        }

        private void UpdateFilAText(string message)
        {
            filATxtBox.Text = message;
        }

        public string AirPressure
        {
            get
            {
                return airPressureTxtBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    airPressureTxtBox.Invoke(new UpdateAirPressureTextDelegate(UpdateAirPressureText), value);
                }
                else
                {
                    airPressureTxtBox.Text = value;
                }
            }
        }

        private void UpdateAirPressureText(string message)
        {
            airPressureTxtBox.Text = message;
        }
        public string DeviceIdText
        {
            get
            {
                return DevIdTxtBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    DevIdTxtBox.Invoke(new UpdateDeviceIdTextDelegate(UpdateDeviceIdText), value);
                }
                else
                {
                    DevIdTxtBox.Text = value;
                }
            }
        }

        private void UpdateDeviceIdText(string message)
        {
            DevIdTxtBox.Text = message;
        }

        public string PublishMessageText
        {
            get
            {
                return listBox1.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    listBox1.Invoke(new UpdateMessageTextDelegate(UpdateMessageText), value);
                }
                else
                {
                    listBox1.Items.Insert(0, value);
                }
            }
        }

        private void UpdateMessageText(string message)
        {
            listBox1.Items.Insert(0, message);
        }

        private void DeviceScanBtn_Click(object sender, EventArgs e)
        {
            objCanCom.scanDevice();
        }

        private void DeviceConnectBtn_Click(object sender, EventArgs e)
        {
            objCanCom.connectDevice();

            if(GlobalFunctions.ValueCANStatus==true)
            {
                CANStatusLbl.Text = "Connected";
                CANStatusLbl.ForeColor = Color.Green;
            }
            else
            {
                CANStatusLbl.Text = "Not connected";
                CANStatusLbl.ForeColor = Color.Red;
            }
        }


        public string DeviceListBox
        {
            get
            {
                return devListBox.Text;
            }

            set
            {
                if (InvokeRequired)
                {
                    devListBox.Invoke(new UpdateDeviceSerialNumberDelegate(UpdateDeviceSerialNumber), value);
                }
                else
                {
                    devListBox.Items.Insert(0, value);
                }
            }
        }

        private void UpdateDeviceSerialNumber(string message)
        {
            devListBox.Items.Insert(0, message);
        }

        public void ClearDevListBox()
        {
            devListBox.Items.Clear();
        }

        private void Form1_onFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "My Application", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }



        //public  void BlinkLEDImage(Object sender)
        //{
        //        if (!bBlink)
        //        {
        //            MasterLed.BackgroundImage.Dispose();
        //            LampOnLed.BackgroundImage.Dispose();
        //            StandByLed.BackgroundImage.Dispose();
        //            ResetLed.BackgroundImage.Dispose();

        //            MasterLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //            LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //            StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //            ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //            bBlink = true;
        //        }
        //        else if (bBlink)
        //        {
        //            MasterLed.BackgroundImage.Dispose();
        //            LampOnLed.BackgroundImage.Dispose();
        //            StandByLed.BackgroundImage.Dispose();
        //            ResetLed.BackgroundImage.Dispose();
        //            MasterLed.BackgroundImage = SendMessageWinApp.Properties.Resources.BlueLED;
        //            LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGreen;
        //            StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDOrange;
        //            ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDRed;
        //            bBlink = false;
        //        }
        //}

        private void connectionStrTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        //public void StopBlinkLED()
        //{
        //    if (IsBlink != false)
        //    {
        //        IsBlink = false;
        //        TimerBlink.Dispose();
        //        MasterLed.BackgroundImage.Dispose();
        //        LampOnLed.BackgroundImage.Dispose();
        //        StandByLed.BackgroundImage.Dispose();
        //        ResetLed.BackgroundImage.Dispose();

        //        MasterLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //        LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //        StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //        ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
        //    }
        //}

        public void SetDeviceState(string devState, string powerLvl, string faultCode)
        {
            if (devState == "LAMPON")
            {
                //LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGreen;
                //StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                //ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                SetLEDStatus(lbLedLampON);

            }
            else if (devState == "RESET")
            {
                //LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                //StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                //ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDRed;
                SetLEDStatus(lbLedReset);
            }
            else if (devState == "STANDBY")
            {
                //LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                //StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDOrange;
                //ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                SetLEDStatus(lbLedStandby);
            }
            else if (devState == "FAULT")
            {
                //LampOnLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                //StandByLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDGrey;
                //ResetLed.BackgroundImage = SendMessageWinApp.Properties.Resources.LEDRed;
                SetLEDStatus(lbLedProcess);
            }
            LblPanel.Text = @"POWER LEVEL " + powerLvl + "%  \n" + devState;

            //if (faultCode.Length != 0)
            //{
            //    string sQurey = @"select * from LH10_MK2_Fault where FaultCode = " + faultCode;
            //    using (SqlCommand command = new SqlCommand(sQurey, dbConn))
            //    {
            //        SqlDataReader reader = command.ExecuteReader();
            //        if (reader.Read())
            //        {
            //            string sFaultStr = reader.GetString(1);
            //            if (sFaultStr.Length > 0)
            //                FaultLbl.Text = "[#" + faultCode + "]  " + sFaultStr;
            //        }
            //        else
            //            FaultLbl.Text = "[#" + faultCode + "]  " + "Unknown Fault";

            //        reader.Close();
            //        int fCode = Convert.ToInt32(faultCode);
            //    }
            //}
        }

        private void BtnLampOn_Click(object sender, EventArgs e)
        {

        }

        private void ckEnableControlMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEnableControlMode.Checked == true)
            {
                pnlControlCommands.Enabled = true;
            }
            else
            {
                pnlControlCommands.Enabled = false;
            }


            if (ckEnableControlMode.Checked == true)
            {
                GlobalFunctions.System_Normal_Mode = true;
                Console.WriteLine("System_Normal_Mode:" + GlobalFunctions.System_Normal_Mode);
            }
            else
            {
                GlobalFunctions.System_Normal_Mode = false;
                Console.WriteLine("System_Normal_Mode:" + GlobalFunctions.System_Normal_Mode);
            }

        }

        private bool DeviceConnectionStatus()
        {
            if(GlobalFunctions.EdgeDeviceStatus==true)
            {
                //check connection status and return value
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private bool IsDeviceTypeSlave()
        {
            if (Convert.ToInt32(GlobalFunctions.Sending_Unit_Address_Y) == 0)
            {
                //check connection status and return value
                return false;
            }
            else
            {
                //check connection status and return value
                return true;
            }
         
        }

        private void ckEnableControlMode_MouseDown(object sender, MouseEventArgs e)
        {
            if (ckEnableControlMode.Checked == false)
            {
                //Check if device connected
                if (DeviceConnectionStatus() == false)
                {
                    MessageBox.Show("Device not connected");
                    return;
                }

                //Check if the connected device is slave device
                //Only slave devices can be controlled from this app
                if (IsDeviceTypeSlave() == false)
                {
                    MessageBox.Show("The connected Device type must be a Slave device to establish remote control access.\nPlease connect a slave device and try");
                    return;
                }
            }
        }

        private void rbLampOn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LBSoft.IndustrialCtrls.Leds.LBLed dfs = new LBSoft.IndustrialCtrls.Leds.LBLed();
                dfs.Label = "dsfdsf";

                panel5.Controls.Add(dfs);
            }
            catch (Exception ex)
            //dfs.Dock = DockStyle.Left;
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCtlLampON_Click(object sender, EventArgs e)
        {
            lbLedStandby.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedReset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedProcess.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedLampON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
            //SetLEDStatus(lbLedLampON);
            GlobalFunctions.System_State = 10;
        }

        private void btnCtlStandby_Click(object sender, EventArgs e)
        {
            lbLedLampON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedReset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedProcess.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedStandby.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
            //SetLEDStatus(lbLedStandby);
            GlobalFunctions.System_State = 6;
        }

        private void btnCtlReset_Click(object sender, EventArgs e)
        {
            lbLedLampON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedStandby.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedProcess.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedReset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
            //SetLEDStatus(lbLedReset);
            GlobalFunctions.System_State = 3;
        }

        private void SetLEDStatus(LBSoft.IndustrialCtrls.Leds.LBLed lb)
        {
            lbLedLampON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedStandby.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedReset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lbLedProcess.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;

           // lb.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
/*            for (int i = 0; i < 100; i++)
            {
                Application.DoEvents();
                Thread.Sleep(50);
            }*/
            //// lbLedProcess.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            lb.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
        }

        private void btnCtlPowerUp_Click(object sender, EventArgs e)
        {

            string stringHex = GlobalFunctions.GblPowerLevel;
            Console.WriteLine("GlobalFunctions.GblPowerLevel:" + Convert.ToInt32(GlobalFunctions.GblPowerLevel, 16));

            if (Convert.ToInt32(GlobalFunctions.GblPowerLevel, 16) >= 35 && Convert.ToInt32(GlobalFunctions.GblPowerLevel, 16) < 100)
            {
                int intFromHex = int.Parse(stringHex, System.Globalization.NumberStyles.HexNumber) + 1;
                GlobalFunctions.GblPowerLevel = intFromHex.ToString("X");
            }
        }

        private void btnCtlPowerDown_Click(object sender, EventArgs e)
        {
            string stringHex = GlobalFunctions.GblPowerLevel;
            Console.WriteLine("GlobalFunctions.GblPowerLevel:" + Convert.ToInt32(GlobalFunctions.GblPowerLevel, 16));
            if (Convert.ToInt32(GlobalFunctions.GblPowerLevel, 16) > 35 && Convert.ToInt32(GlobalFunctions.GblPowerLevel, 16) <= 100)
            {
                int intFromHex = int.Parse(stringHex, System.Globalization.NumberStyles.HexNumber) - 1;
                GlobalFunctions.GblPowerLevel = intFromHex.ToString("X");
            }
        }

        private void ckPublishData_CheckedChanged(object sender, EventArgs e)
        {
            if(ckPublishData.Checked == true)
            {
                GlobalFunctions.DataPublishToCloudStatus = true;
            }
            else
            {
                GlobalFunctions.DataPublishToCloudStatus = false;
            }
        }
    }
}
