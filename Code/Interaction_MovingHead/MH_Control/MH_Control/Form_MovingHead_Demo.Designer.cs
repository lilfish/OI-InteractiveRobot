namespace MH_Control
{
    partial class Form_MovingHead_Demo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_SerialConnect = new System.Windows.Forms.Button();
            this.cbx_COM_PORTS = new System.Windows.Forms.ComboBox();
            this.btn_Test_RandomPos = new System.Windows.Forms.Button();
            this.lbl_debug_text = new System.Windows.Forms.Label();
            this.pnl_ControllerSimulation = new System.Windows.Forms.Panel();
            this.btn_StartDemo = new System.Windows.Forms.Button();
            this.btnDisconnectServer = new System.Windows.Forms.Button();
            this.gbxRemoteConnection = new System.Windows.Forms.GroupBox();
            this.tbxServerPort = new System.Windows.Forms.TextBox();
            this.tbxServerIP = new System.Windows.Forms.TextBox();
            this.btnConnectServer = new System.Windows.Forms.Button();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.gbxMessageHistory = new System.Windows.Forms.GroupBox();
            this.tbxMessageHistory = new System.Windows.Forms.TextBox();
            this.cbx_ProgramModes = new System.Windows.Forms.ComboBox();
            this.gbxRemoteConnection.SuspendLayout();
            this.gbxMessageHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SerialConnect
            // 
            this.btn_SerialConnect.Location = new System.Drawing.Point(12, 12);
            this.btn_SerialConnect.Name = "btn_SerialConnect";
            this.btn_SerialConnect.Size = new System.Drawing.Size(135, 31);
            this.btn_SerialConnect.TabIndex = 0;
            this.btn_SerialConnect.Text = "Serial Connect";
            this.btn_SerialConnect.UseVisualStyleBackColor = true;
            this.btn_SerialConnect.Click += new System.EventHandler(this.btn_SerialConnect_Click);
            // 
            // cbx_COM_PORTS
            // 
            this.cbx_COM_PORTS.FormattingEnabled = true;
            this.cbx_COM_PORTS.Location = new System.Drawing.Point(12, 49);
            this.cbx_COM_PORTS.Name = "cbx_COM_PORTS";
            this.cbx_COM_PORTS.Size = new System.Drawing.Size(135, 24);
            this.cbx_COM_PORTS.TabIndex = 1;
            // 
            // btn_Test_RandomPos
            // 
            this.btn_Test_RandomPos.Location = new System.Drawing.Point(805, 12);
            this.btn_Test_RandomPos.Name = "btn_Test_RandomPos";
            this.btn_Test_RandomPos.Size = new System.Drawing.Size(189, 31);
            this.btn_Test_RandomPos.TabIndex = 2;
            this.btn_Test_RandomPos.Text = "goToRandom | Pos";
            this.btn_Test_RandomPos.UseVisualStyleBackColor = true;
            this.btn_Test_RandomPos.Click += new System.EventHandler(this.btn_Test_RandomPos_Click);
            // 
            // lbl_debug_text
            // 
            this.lbl_debug_text.AutoSize = true;
            this.lbl_debug_text.Location = new System.Drawing.Point(805, 46);
            this.lbl_debug_text.Name = "lbl_debug_text";
            this.lbl_debug_text.Size = new System.Drawing.Size(74, 17);
            this.lbl_debug_text.TabIndex = 3;
            this.lbl_debug_text.Text = "debug text";
            // 
            // pnl_ControllerSimulation
            // 
            this.pnl_ControllerSimulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ControllerSimulation.Location = new System.Drawing.Point(153, 12);
            this.pnl_ControllerSimulation.MaximumSize = new System.Drawing.Size(320, 300);
            this.pnl_ControllerSimulation.MinimumSize = new System.Drawing.Size(320, 300);
            this.pnl_ControllerSimulation.Name = "pnl_ControllerSimulation";
            this.pnl_ControllerSimulation.Size = new System.Drawing.Size(320, 300);
            this.pnl_ControllerSimulation.TabIndex = 4;
            // 
            // btn_StartDemo
            // 
            this.btn_StartDemo.Location = new System.Drawing.Point(12, 146);
            this.btn_StartDemo.Name = "btn_StartDemo";
            this.btn_StartDemo.Size = new System.Drawing.Size(135, 31);
            this.btn_StartDemo.TabIndex = 5;
            this.btn_StartDemo.Text = "Start Demo";
            this.btn_StartDemo.UseVisualStyleBackColor = true;
            this.btn_StartDemo.Click += new System.EventHandler(this.btn_StartDemo_Click);
            // 
            // btnDisconnectServer
            // 
            this.btnDisconnectServer.Location = new System.Drawing.Point(805, 274);
            this.btnDisconnectServer.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnDisconnectServer.Name = "btnDisconnectServer";
            this.btnDisconnectServer.Size = new System.Drawing.Size(88, 25);
            this.btnDisconnectServer.TabIndex = 16;
            this.btnDisconnectServer.Text = "Disconnect";
            this.btnDisconnectServer.UseVisualStyleBackColor = true;
            this.btnDisconnectServer.Click += new System.EventHandler(this.btnDisconnectServer_Click);
            // 
            // gbxRemoteConnection
            // 
            this.gbxRemoteConnection.Controls.Add(this.tbxServerPort);
            this.gbxRemoteConnection.Controls.Add(this.tbxServerIP);
            this.gbxRemoteConnection.Controls.Add(this.btnConnectServer);
            this.gbxRemoteConnection.Controls.Add(this.lblServerIP);
            this.gbxRemoteConnection.Controls.Add(this.lblServerPort);
            this.gbxRemoteConnection.Location = new System.Drawing.Point(665, 177);
            this.gbxRemoteConnection.Name = "gbxRemoteConnection";
            this.gbxRemoteConnection.Size = new System.Drawing.Size(244, 91);
            this.gbxRemoteConnection.TabIndex = 17;
            this.gbxRemoteConnection.TabStop = false;
            this.gbxRemoteConnection.Text = "Remote Connection";
            // 
            // tbxServerPort
            // 
            this.tbxServerPort.Location = new System.Drawing.Point(190, 21);
            this.tbxServerPort.MinimumSize = new System.Drawing.Size(38, 22);
            this.tbxServerPort.Name = "tbxServerPort";
            this.tbxServerPort.Size = new System.Drawing.Size(38, 22);
            this.tbxServerPort.TabIndex = 6;
            // 
            // tbxServerIP
            // 
            this.tbxServerIP.Location = new System.Drawing.Point(35, 21);
            this.tbxServerIP.MinimumSize = new System.Drawing.Size(105, 22);
            this.tbxServerIP.Name = "tbxServerIP";
            this.tbxServerIP.Size = new System.Drawing.Size(105, 22);
            this.tbxServerIP.TabIndex = 5;
            // 
            // btnConnectServer
            // 
            this.btnConnectServer.Location = new System.Drawing.Point(153, 49);
            this.btnConnectServer.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnConnectServer.Name = "btnConnectServer";
            this.btnConnectServer.Size = new System.Drawing.Size(75, 25);
            this.btnConnectServer.TabIndex = 8;
            this.btnConnectServer.Text = "Connect";
            this.btnConnectServer.UseVisualStyleBackColor = true;
            this.btnConnectServer.Click += new System.EventHandler(this.btnConnectServer_Click);
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(5, 24);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(24, 17);
            this.lblServerIP.TabIndex = 9;
            this.lblServerIP.Text = "IP:";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(146, 24);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(38, 17);
            this.lblServerPort.TabIndex = 11;
            this.lblServerPort.Text = "Port:";
            // 
            // gbxMessageHistory
            // 
            this.gbxMessageHistory.Controls.Add(this.tbxMessageHistory);
            this.gbxMessageHistory.Location = new System.Drawing.Point(665, 300);
            this.gbxMessageHistory.Name = "gbxMessageHistory";
            this.gbxMessageHistory.Size = new System.Drawing.Size(329, 231);
            this.gbxMessageHistory.TabIndex = 18;
            this.gbxMessageHistory.TabStop = false;
            this.gbxMessageHistory.Text = "Message History";
            // 
            // tbxMessageHistory
            // 
            this.tbxMessageHistory.Location = new System.Drawing.Point(6, 21);
            this.tbxMessageHistory.Multiline = true;
            this.tbxMessageHistory.Name = "tbxMessageHistory";
            this.tbxMessageHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessageHistory.Size = new System.Drawing.Size(317, 204);
            this.tbxMessageHistory.TabIndex = 2;
            // 
            // cbx_ProgramModes
            // 
            this.cbx_ProgramModes.FormattingEnabled = true;
            this.cbx_ProgramModes.Location = new System.Drawing.Point(12, 183);
            this.cbx_ProgramModes.Name = "cbx_ProgramModes";
            this.cbx_ProgramModes.Size = new System.Drawing.Size(135, 24);
            this.cbx_ProgramModes.TabIndex = 19;
            // 
            // Form_MovingHead_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 673);
            this.Controls.Add(this.cbx_ProgramModes);
            this.Controls.Add(this.gbxMessageHistory);
            this.Controls.Add(this.btnDisconnectServer);
            this.Controls.Add(this.gbxRemoteConnection);
            this.Controls.Add(this.btn_StartDemo);
            this.Controls.Add(this.pnl_ControllerSimulation);
            this.Controls.Add(this.lbl_debug_text);
            this.Controls.Add(this.btn_Test_RandomPos);
            this.Controls.Add(this.cbx_COM_PORTS);
            this.Controls.Add(this.btn_SerialConnect);
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "Form_MovingHead_Demo";
            this.Text = "MovingHead_Demo";
            this.Load += new System.EventHandler(this.Form_MovingHead_Demo_Load);
            this.gbxRemoteConnection.ResumeLayout(false);
            this.gbxRemoteConnection.PerformLayout();
            this.gbxMessageHistory.ResumeLayout(false);
            this.gbxMessageHistory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SerialConnect;
        private System.Windows.Forms.ComboBox cbx_COM_PORTS;
        private System.Windows.Forms.Button btn_Test_RandomPos;
        private System.Windows.Forms.Label lbl_debug_text;
        private System.Windows.Forms.Panel pnl_ControllerSimulation;
        private System.Windows.Forms.Button btn_StartDemo;
        private System.Windows.Forms.Button btnDisconnectServer;
        private System.Windows.Forms.GroupBox gbxRemoteConnection;
        private System.Windows.Forms.TextBox tbxServerPort;
        private System.Windows.Forms.TextBox tbxServerIP;
        private System.Windows.Forms.Button btnConnectServer;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.GroupBox gbxMessageHistory;
        private System.Windows.Forms.TextBox tbxMessageHistory;
        private System.Windows.Forms.ComboBox cbx_ProgramModes;
    }
}

