
namespace SendMessageWinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.CANStatusLbl = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.StatusLbl = new System.Windows.Forms.Label();
            this.StartBtn = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.connectionStrTextBox = new System.Windows.Forms.RichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.deviceConnectBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.deviceScanBtn = new System.Windows.Forms.Button();
            this.devListBox = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.lbLedProcess = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label18 = new System.Windows.Forms.Label();
            this.lbLedLampON = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label17 = new System.Windows.Forms.Label();
            this.lbLedStandby = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label16 = new System.Windows.Forms.Label();
            this.lbLedReset = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.FaultLbl = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.airPressureTxtBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ckEnableControlMode = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlControlCommands = new System.Windows.Forms.Panel();
            this.btnCtlPowerDown = new System.Windows.Forms.Button();
            this.btnCtlPowerUp = new System.Windows.Forms.Button();
            this.btnCtlReset = new System.Windows.Forms.Button();
            this.btnCtlStandby = new System.Windows.Forms.Button();
            this.btnCtlLampON = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.LblPanel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.filATxtBox = new System.Windows.Forms.TextBox();
            this.MagATxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MagBTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.powerLvlTxtBox = new System.Windows.Forms.TextBox();
            this.DevIdTxtBox = new System.Windows.Forms.TextBox();
            this.ckPublishData = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlControlCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.CANStatusLbl);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.StopBtn);
            this.panel1.Controls.Add(this.StatusLbl);
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 619);
            this.panel1.TabIndex = 8;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Black;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Dock = System.Windows.Forms.DockStyle.Top;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(908, 41);
            this.label26.TabIndex = 53;
            this.label26.Text = "Azure IoT Data Publisher";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Black;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(-1, 144);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(234, 30);
            this.label25.TabIndex = 52;
            this.label25.Text = "Connection Status";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CANStatusLbl
            // 
            this.CANStatusLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CANStatusLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CANStatusLbl.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.CANStatusLbl.ForeColor = System.Drawing.Color.Red;
            this.CANStatusLbl.Location = new System.Drawing.Point(114, 174);
            this.CANStatusLbl.Name = "CANStatusLbl";
            this.CANStatusLbl.Size = new System.Drawing.Size(118, 23);
            this.CANStatusLbl.TabIndex = 51;
            this.CANStatusLbl.Text = "Not connected";
            this.CANStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(-1, 174);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 23);
            this.label24.TabIndex = 50;
            this.label24.Text = "Device CAN  :";
            // 
            // StopBtn
            // 
            this.StopBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StopBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StopBtn.ForeColor = System.Drawing.Color.Firebrick;
            this.StopBtn.Location = new System.Drawing.Point(15, 98);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 41);
            this.StopBtn.TabIndex = 17;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = false;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // StatusLbl
            // 
            this.StatusLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StatusLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusLbl.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.StatusLbl.ForeColor = System.Drawing.Color.Red;
            this.StatusLbl.Location = new System.Drawing.Point(114, 196);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(118, 23);
            this.StatusLbl.TabIndex = 25;
            this.StatusLbl.Text = "Not connected";
            this.StatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StartBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartBtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.StartBtn.Location = new System.Drawing.Point(15, 52);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 41);
            this.StartBtn.TabIndex = 16;
            this.StartBtn.Text = "Start ";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.ckPublishData);
            this.panel8.Controls.Add(this.DisconnectBtn);
            this.panel8.Controls.Add(this.connectionStrTextBox);
            this.panel8.Controls.Add(this.label20);
            this.panel8.Controls.Add(this.label11);
            this.panel8.Controls.Add(this.ConnectBtn);
            this.panel8.Location = new System.Drawing.Point(-1, 417);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(233, 182);
            this.panel8.TabIndex = 49;
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.BackColor = System.Drawing.Color.Azure;
            this.DisconnectBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DisconnectBtn.Location = new System.Drawing.Point(113, 142);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(106, 29);
            this.DisconnectBtn.TabIndex = 18;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // connectionStrTextBox
            // 
            this.connectionStrTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionStrTextBox.Location = new System.Drawing.Point(9, 63);
            this.connectionStrTextBox.Name = "connectionStrTextBox";
            this.connectionStrTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.connectionStrTextBox.Size = new System.Drawing.Size(210, 73);
            this.connectionStrTextBox.TabIndex = 24;
            this.connectionStrTextBox.Text = "HostName=AltranHub21.azure-devices.net;DeviceId=MyDeskDevice;SharedAccessKey=Xr5v" +
    "x7fhFM3kn8ffdHRjPsYzGQQDpvxEIMfLtb+U8NI=";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(229, 30);
            this.label20.TabIndex = 22;
            this.label20.Text = "Cloud Settings";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(9, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Hub Address";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.Azure;
            this.ConnectBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ConnectBtn.Location = new System.Drawing.Point(9, 142);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(98, 29);
            this.ConnectBtn.TabIndex = 21;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.deviceConnectBtn);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.deviceScanBtn);
            this.panel6.Controls.Add(this.devListBox);
            this.panel6.Location = new System.Drawing.Point(-2, 219);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(235, 196);
            this.panel6.TabIndex = 47;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(233, 30);
            this.label19.TabIndex = 7;
            this.label19.Text = "Device Settings";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceConnectBtn
            // 
            this.deviceConnectBtn.BackColor = System.Drawing.Color.Azure;
            this.deviceConnectBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deviceConnectBtn.Location = new System.Drawing.Point(52, 156);
            this.deviceConnectBtn.Name = "deviceConnectBtn";
            this.deviceConnectBtn.Size = new System.Drawing.Size(101, 30);
            this.deviceConnectBtn.TabIndex = 2;
            this.deviceConnectBtn.Text = "Connect";
            this.deviceConnectBtn.UseVisualStyleBackColor = false;
            this.deviceConnectBtn.Click += new System.EventHandler(this.DeviceConnectBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(6, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Device List";
            // 
            // deviceScanBtn
            // 
            this.deviceScanBtn.BackColor = System.Drawing.Color.Azure;
            this.deviceScanBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deviceScanBtn.Location = new System.Drawing.Point(135, 36);
            this.deviceScanBtn.Name = "deviceScanBtn";
            this.deviceScanBtn.Size = new System.Drawing.Size(73, 24);
            this.deviceScanBtn.TabIndex = 1;
            this.deviceScanBtn.Text = "Scan ";
            this.deviceScanBtn.UseVisualStyleBackColor = false;
            this.deviceScanBtn.Click += new System.EventHandler(this.DeviceScanBtn_Click);
            // 
            // devListBox
            // 
            this.devListBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.devListBox.FormattingEnabled = true;
            this.devListBox.ItemHeight = 17;
            this.devListBox.Location = new System.Drawing.Point(6, 61);
            this.devListBox.Name = "devListBox";
            this.devListBox.Size = new System.Drawing.Size(202, 89);
            this.devListBox.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(-1, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 23);
            this.label12.TabIndex = 24;
            this.label12.Text = "Azure Cloud :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(461, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 15);
            this.label13.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.FaultLbl);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.airPressureTxtBox);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.LblPanel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.filATxtBox);
            this.panel2.Controls.Add(this.MagATxtBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.MagBTextBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.powerLvlTxtBox);
            this.panel2.Controls.Add(this.DevIdTxtBox);
            this.panel2.Location = new System.Drawing.Point(253, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 551);
            this.panel2.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 30);
            this.label4.TabIndex = 279;
            this.label4.Text = "System State";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLedProcess, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLedLampON, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label17, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLedStandby, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbLedReset, 2, 0);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 76);
            this.tableLayoutPanel1.TabIndex = 278;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(179, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 28);
            this.label14.TabIndex = 279;
            this.label14.Text = "Fault";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLedProcess
            // 
            this.lbLedProcess.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLedProcess.BackColor = System.Drawing.Color.Transparent;
            this.lbLedProcess.BlinkInterval = 250;
            this.lbLedProcess.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLedProcess.Label = "";
            this.lbLedProcess.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom;
            this.lbLedProcess.LedColor = System.Drawing.Color.Red;
            this.lbLedProcess.LedSize = new System.Drawing.SizeF(25F, 25F);
            this.lbLedProcess.Location = new System.Drawing.Point(188, 8);
            this.lbLedProcess.Name = "lbLedProcess";
            this.lbLedProcess.Renderer = null;
            this.lbLedProcess.Size = new System.Drawing.Size(33, 30);
            this.lbLedProcess.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLedProcess.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLedProcess.TabIndex = 275;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(121, 47);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 25);
            this.label18.TabIndex = 277;
            this.label18.Text = "Reset";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLedLampON
            // 
            this.lbLedLampON.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLedLampON.BackColor = System.Drawing.Color.Transparent;
            this.lbLedLampON.BlinkInterval = 100;
            this.lbLedLampON.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLedLampON.Label = "";
            this.lbLedLampON.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom;
            this.lbLedLampON.LedColor = System.Drawing.Color.Lime;
            this.lbLedLampON.LedSize = new System.Drawing.SizeF(25F, 25F);
            this.lbLedLampON.Location = new System.Drawing.Point(13, 8);
            this.lbLedLampON.Name = "lbLedLampON";
            this.lbLedLampON.Renderer = null;
            this.lbLedLampON.Size = new System.Drawing.Size(33, 30);
            this.lbLedLampON.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLedLampON.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLedLampON.TabIndex = 273;
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(63, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 28);
            this.label17.TabIndex = 276;
            this.label17.Text = "StandBy";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLedStandby
            // 
            this.lbLedStandby.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLedStandby.BackColor = System.Drawing.Color.Transparent;
            this.lbLedStandby.BlinkInterval = 100;
            this.lbLedStandby.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLedStandby.Label = "";
            this.lbLedStandby.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom;
            this.lbLedStandby.LedColor = System.Drawing.Color.DarkOrange;
            this.lbLedStandby.LedSize = new System.Drawing.SizeF(25F, 25F);
            this.lbLedStandby.Location = new System.Drawing.Point(71, 8);
            this.lbLedStandby.Name = "lbLedStandby";
            this.lbLedStandby.Renderer = null;
            this.lbLedStandby.Size = new System.Drawing.Size(33, 30);
            this.lbLedStandby.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLedStandby.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLedStandby.TabIndex = 272;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(5, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 28);
            this.label16.TabIndex = 275;
            this.label16.Text = "Lamp ON";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLedReset
            // 
            this.lbLedReset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLedReset.BackColor = System.Drawing.Color.Transparent;
            this.lbLedReset.BlinkInterval = 100;
            this.lbLedReset.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbLedReset.Label = "";
            this.lbLedReset.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom;
            this.lbLedReset.LedColor = System.Drawing.Color.Yellow;
            this.lbLedReset.LedSize = new System.Drawing.SizeF(25F, 25F);
            this.lbLedReset.Location = new System.Drawing.Point(129, 8);
            this.lbLedReset.Name = "lbLedReset";
            this.lbLedReset.Renderer = null;
            this.lbLedReset.Size = new System.Drawing.Size(33, 30);
            this.lbLedReset.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLedReset.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLedReset.TabIndex = 274;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(2, 323);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 17);
            this.label22.TabIndex = 30;
            this.label22.Text = "Data Log";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(643, 31);
            this.label21.TabIndex = 29;
            this.label21.Text = "Live Data Monitor";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FaultLbl
            // 
            this.FaultLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FaultLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.FaultLbl.ForeColor = System.Drawing.Color.Red;
            this.FaultLbl.Location = new System.Drawing.Point(69, 144);
            this.FaultLbl.Name = "FaultLbl";
            this.FaultLbl.Size = new System.Drawing.Size(166, 21);
            this.FaultLbl.TabIndex = 27;
            this.FaultLbl.Text = "No Fault";
            this.FaultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FaultLbl.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.ForeColor = System.Drawing.Color.Aqua;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(-1, 341);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(643, 214);
            this.listBox1.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Device Id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(0, 144);
            this.label10.MaximumSize = new System.Drawing.Size(200, 25);
            this.label10.MinimumSize = new System.Drawing.Size(50, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 25);
            this.label10.TabIndex = 26;
            this.label10.Text = "Fault : ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mag A Current (mADC)";
            // 
            // airPressureTxtBox
            // 
            this.airPressureTxtBox.Location = new System.Drawing.Point(480, 274);
            this.airPressureTxtBox.Name = "airPressureTxtBox";
            this.airPressureTxtBox.Size = new System.Drawing.Size(76, 29);
            this.airPressureTxtBox.TabIndex = 11;
            this.airPressureTxtBox.Text = "0000.00";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.ckEnableControlMode);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.pnlControlCommands);
            this.panel5.Location = new System.Drawing.Point(376, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(243, 145);
            this.panel5.TabIndex = 46;
            // 
            // ckEnableControlMode
            // 
            this.ckEnableControlMode.AutoSize = true;
            this.ckEnableControlMode.Location = new System.Drawing.Point(14, 35);
            this.ckEnableControlMode.Name = "ckEnableControlMode";
            this.ckEnableControlMode.Size = new System.Drawing.Size(175, 25);
            this.ckEnableControlMode.TabIndex = 29;
            this.ckEnableControlMode.Text = "Enable Control Mode";
            this.ckEnableControlMode.UseVisualStyleBackColor = true;
            this.ckEnableControlMode.CheckedChanged += new System.EventHandler(this.ckEnableControlMode_CheckedChanged);
            this.ckEnableControlMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ckEnableControlMode_MouseDown);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 30);
            this.label9.TabIndex = 24;
            this.label9.Text = "Device Control Panel";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlControlCommands
            // 
            this.pnlControlCommands.Controls.Add(this.btnCtlPowerDown);
            this.pnlControlCommands.Controls.Add(this.btnCtlPowerUp);
            this.pnlControlCommands.Controls.Add(this.btnCtlReset);
            this.pnlControlCommands.Controls.Add(this.btnCtlStandby);
            this.pnlControlCommands.Controls.Add(this.btnCtlLampON);
            this.pnlControlCommands.Enabled = false;
            this.pnlControlCommands.Location = new System.Drawing.Point(9, 64);
            this.pnlControlCommands.Name = "pnlControlCommands";
            this.pnlControlCommands.Size = new System.Drawing.Size(230, 78);
            this.pnlControlCommands.TabIndex = 282;
            // 
            // btnCtlPowerDown
            // 
            this.btnCtlPowerDown.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCtlPowerDown.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCtlPowerDown.Location = new System.Drawing.Point(124, 39);
            this.btnCtlPowerDown.Name = "btnCtlPowerDown";
            this.btnCtlPowerDown.Size = new System.Drawing.Size(68, 37);
            this.btnCtlPowerDown.TabIndex = 283;
            this.btnCtlPowerDown.Text = "-";
            this.btnCtlPowerDown.UseVisualStyleBackColor = false;
            this.btnCtlPowerDown.Click += new System.EventHandler(this.btnCtlPowerDown_Click);
            // 
            // btnCtlPowerUp
            // 
            this.btnCtlPowerUp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCtlPowerUp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCtlPowerUp.Location = new System.Drawing.Point(30, 38);
            this.btnCtlPowerUp.Name = "btnCtlPowerUp";
            this.btnCtlPowerUp.Size = new System.Drawing.Size(68, 37);
            this.btnCtlPowerUp.TabIndex = 282;
            this.btnCtlPowerUp.Text = "+";
            this.btnCtlPowerUp.UseVisualStyleBackColor = false;
            this.btnCtlPowerUp.Click += new System.EventHandler(this.btnCtlPowerUp_Click);
            // 
            // btnCtlReset
            // 
            this.btnCtlReset.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCtlReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCtlReset.Location = new System.Drawing.Point(153, 1);
            this.btnCtlReset.Name = "btnCtlReset";
            this.btnCtlReset.Size = new System.Drawing.Size(68, 37);
            this.btnCtlReset.TabIndex = 281;
            this.btnCtlReset.Text = "Reset";
            this.btnCtlReset.UseVisualStyleBackColor = false;
            this.btnCtlReset.Click += new System.EventHandler(this.btnCtlReset_Click);
            // 
            // btnCtlStandby
            // 
            this.btnCtlStandby.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCtlStandby.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCtlStandby.Location = new System.Drawing.Point(79, 1);
            this.btnCtlStandby.Name = "btnCtlStandby";
            this.btnCtlStandby.Size = new System.Drawing.Size(68, 37);
            this.btnCtlStandby.TabIndex = 280;
            this.btnCtlStandby.Text = "Standby";
            this.btnCtlStandby.UseVisualStyleBackColor = false;
            this.btnCtlStandby.Click += new System.EventHandler(this.btnCtlStandby_Click);
            // 
            // btnCtlLampON
            // 
            this.btnCtlLampON.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCtlLampON.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCtlLampON.Location = new System.Drawing.Point(5, 1);
            this.btnCtlLampON.Name = "btnCtlLampON";
            this.btnCtlLampON.Size = new System.Drawing.Size(68, 37);
            this.btnCtlLampON.TabIndex = 279;
            this.btnCtlLampON.Text = "LampON";
            this.btnCtlLampON.UseVisualStyleBackColor = false;
            this.btnCtlLampON.Click += new System.EventHandler(this.btnCtlLampON_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Power Level (%)";
            // 
            // LblPanel
            // 
            this.LblPanel.BackColor = System.Drawing.Color.Yellow;
            this.LblPanel.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblPanel.Location = new System.Drawing.Point(241, 38);
            this.LblPanel.Name = "LblPanel";
            this.LblPanel.Size = new System.Drawing.Size(129, 58);
            this.LblPanel.TabIndex = 28;
            this.LblPanel.Text = "#########\r\n#########";
            this.LblPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mag B Current (mADC)";
            // 
            // filATxtBox
            // 
            this.filATxtBox.Location = new System.Drawing.Point(193, 271);
            this.filATxtBox.Name = "filATxtBox";
            this.filATxtBox.Size = new System.Drawing.Size(91, 29);
            this.filATxtBox.TabIndex = 10;
            this.filATxtBox.Text = "000.00";
            // 
            // MagATxtBox
            // 
            this.MagATxtBox.Location = new System.Drawing.Point(193, 230);
            this.MagATxtBox.Name = "MagATxtBox";
            this.MagATxtBox.Size = new System.Drawing.Size(91, 29);
            this.MagATxtBox.TabIndex = 3;
            this.MagATxtBox.Text = "000.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Air Pressure (VDC)";
            // 
            // MagBTextBox
            // 
            this.MagBTextBox.Location = new System.Drawing.Point(480, 232);
            this.MagBTextBox.Name = "MagBTextBox";
            this.MagBTextBox.Size = new System.Drawing.Size(76, 29);
            this.MagBTextBox.TabIndex = 4;
            this.MagBTextBox.Text = "0000.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(176, 21);
            this.label7.TabIndex = 8;
            this.label7.Text = "Filament A Volt (V RMS)";
            // 
            // powerLvlTxtBox
            // 
            this.powerLvlTxtBox.Location = new System.Drawing.Point(480, 191);
            this.powerLvlTxtBox.Name = "powerLvlTxtBox";
            this.powerLvlTxtBox.Size = new System.Drawing.Size(76, 29);
            this.powerLvlTxtBox.TabIndex = 5;
            this.powerLvlTxtBox.Text = "000.00";
            // 
            // DevIdTxtBox
            // 
            this.DevIdTxtBox.Location = new System.Drawing.Point(193, 192);
            this.DevIdTxtBox.Name = "DevIdTxtBox";
            this.DevIdTxtBox.Size = new System.Drawing.Size(91, 29);
            this.DevIdTxtBox.TabIndex = 7;
            this.DevIdTxtBox.Text = "LH10_MK2";
            // 
            // ckPublishData
            // 
            this.ckPublishData.AutoSize = true;
            this.ckPublishData.Location = new System.Drawing.Point(102, 39);
            this.ckPublishData.Name = "ckPublishData";
            this.ckPublishData.Size = new System.Drawing.Size(120, 25);
            this.ckPublishData.TabIndex = 25;
            this.ckPublishData.Text = "Enable Cloud";
            this.ckPublishData.UseVisualStyleBackColor = true;
            this.ckPublishData.CheckedChanged += new System.EventHandler(this.ckPublishData_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(919, 641);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1600, 900);
            this.Name = "Form1";
            this.Text = "Azure IoT Edge Demo { Publisher }";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnlControlCommands.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox DevIdTxtBox;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox powerLvlTxtBox;
        public System.Windows.Forms.TextBox MagBTextBox;
        public System.Windows.Forms.TextBox MagATxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label StatusLbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button StartBtn;
        public System.Windows.Forms.TextBox airPressureTxtBox;
        public System.Windows.Forms.TextBox filATxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button deviceConnectBtn;
        private System.Windows.Forms.Button deviceScanBtn;
        private System.Windows.Forms.ListBox devListBox;
        private System.Windows.Forms.RichTextBox connectionStrTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label FaultLbl;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ckEnableControlMode;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLedStandby;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLedReset;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLedLampON;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label14;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLedProcess;
        private System.Windows.Forms.Button btnCtlReset;
        private System.Windows.Forms.Button btnCtlStandby;
        private System.Windows.Forms.Button btnCtlLampON;
        private System.Windows.Forms.Panel pnlControlCommands;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label CANStatusLbl;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCtlPowerDown;
        private System.Windows.Forms.Button btnCtlPowerUp;
        private System.Windows.Forms.CheckBox ckPublishData;
    }
}


