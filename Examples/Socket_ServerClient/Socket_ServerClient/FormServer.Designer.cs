namespace Proftaak_Server
{
    partial class FormServer
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
            this.tbxMessageToSend = new System.Windows.Forms.TextBox();
            this.btnMessageSend = new System.Windows.Forms.Button();
            this.tbxMessageHistory = new System.Windows.Forms.TextBox();
            this.tbxClientIP = new System.Windows.Forms.TextBox();
            this.tbxClientPort = new System.Windows.Forms.TextBox();
            this.tbxServerPort = new System.Windows.Forms.TextBox();
            this.tbxServerIP = new System.Windows.Forms.TextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblClientIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.lblClientPort = new System.Windows.Forms.Label();
            this.backgroundWorkerReceiveData = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSendData = new System.ComponentModel.BackgroundWorker();
            this.gbxServer = new System.Windows.Forms.GroupBox();
            this.gbxClient = new System.Windows.Forms.GroupBox();
            this.btnServerStop = new System.Windows.Forms.Button();
            this.btnClientDisconnect = new System.Windows.Forms.Button();
            this.gbxMessageHistory = new System.Windows.Forms.GroupBox();
            this.gbxServer.SuspendLayout();
            this.gbxClient.SuspendLayout();
            this.gbxMessageHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxMessageToSend
            // 
            this.tbxMessageToSend.Location = new System.Drawing.Point(6, 357);
            this.tbxMessageToSend.Name = "tbxMessageToSend";
            this.tbxMessageToSend.Size = new System.Drawing.Size(444, 22);
            this.tbxMessageToSend.TabIndex = 0;
            // 
            // btnMessageSend
            // 
            this.btnMessageSend.Location = new System.Drawing.Point(456, 356);
            this.btnMessageSend.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnMessageSend.Name = "btnMessageSend";
            this.btnMessageSend.Size = new System.Drawing.Size(75, 25);
            this.btnMessageSend.TabIndex = 1;
            this.btnMessageSend.Text = "Send";
            this.btnMessageSend.UseVisualStyleBackColor = true;
            this.btnMessageSend.Click += new System.EventHandler(this.btnMessageSend_Click);
            // 
            // tbxMessageHistory
            // 
            this.tbxMessageHistory.Location = new System.Drawing.Point(6, 21);
            this.tbxMessageHistory.Multiline = true;
            this.tbxMessageHistory.Name = "tbxMessageHistory";
            this.tbxMessageHistory.Size = new System.Drawing.Size(525, 329);
            this.tbxMessageHistory.TabIndex = 2;
            // 
            // tbxClientIP
            // 
            this.tbxClientIP.Location = new System.Drawing.Point(36, 21);
            this.tbxClientIP.MinimumSize = new System.Drawing.Size(105, 22);
            this.tbxClientIP.Name = "tbxClientIP";
            this.tbxClientIP.Size = new System.Drawing.Size(105, 22);
            this.tbxClientIP.TabIndex = 3;
            // 
            // tbxClientPort
            // 
            this.tbxClientPort.Location = new System.Drawing.Point(191, 21);
            this.tbxClientPort.MinimumSize = new System.Drawing.Size(38, 22);
            this.tbxClientPort.Name = "tbxClientPort";
            this.tbxClientPort.Size = new System.Drawing.Size(38, 22);
            this.tbxClientPort.TabIndex = 4;
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
            // btnClientConnect
            // 
            this.btnClientConnect.Location = new System.Drawing.Point(134, 49);
            this.btnClientConnect.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(95, 25);
            this.btnClientConnect.TabIndex = 7;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // btnServerStart
            // 
            this.btnServerStart.Location = new System.Drawing.Point(153, 49);
            this.btnServerStart.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(75, 25);
            this.btnServerStart.TabIndex = 8;
            this.btnServerStart.Text = "Start";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
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
            // lblClientIP
            // 
            this.lblClientIP.AutoSize = true;
            this.lblClientIP.Location = new System.Drawing.Point(6, 24);
            this.lblClientIP.Name = "lblClientIP";
            this.lblClientIP.Size = new System.Drawing.Size(24, 17);
            this.lblClientIP.TabIndex = 10;
            this.lblClientIP.Text = "IP:";
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
            // lblClientPort
            // 
            this.lblClientPort.AutoSize = true;
            this.lblClientPort.Location = new System.Drawing.Point(147, 24);
            this.lblClientPort.Name = "lblClientPort";
            this.lblClientPort.Size = new System.Drawing.Size(38, 17);
            this.lblClientPort.TabIndex = 12;
            this.lblClientPort.Text = "Port:";
            // 
            // backgroundWorkerReceiveData
            // 
            this.backgroundWorkerReceiveData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerReceiveData_DoWork);
            // 
            // backgroundWorkerSendData
            // 
            this.backgroundWorkerSendData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSendData_DoWork);
            // 
            // gbxServer
            // 
            this.gbxServer.Controls.Add(this.tbxServerPort);
            this.gbxServer.Controls.Add(this.tbxServerIP);
            this.gbxServer.Controls.Add(this.btnServerStart);
            this.gbxServer.Controls.Add(this.lblServerIP);
            this.gbxServer.Controls.Add(this.lblServerPort);
            this.gbxServer.Location = new System.Drawing.Point(13, 13);
            this.gbxServer.Name = "gbxServer";
            this.gbxServer.Size = new System.Drawing.Size(244, 91);
            this.gbxServer.TabIndex = 15;
            this.gbxServer.TabStop = false;
            this.gbxServer.Text = "Server";
            // 
            // gbxClient
            // 
            this.gbxClient.Controls.Add(this.lblClientIP);
            this.gbxClient.Controls.Add(this.tbxClientIP);
            this.gbxClient.Controls.Add(this.tbxClientPort);
            this.gbxClient.Controls.Add(this.lblClientPort);
            this.gbxClient.Controls.Add(this.btnClientConnect);
            this.gbxClient.Location = new System.Drawing.Point(263, 13);
            this.gbxClient.Name = "gbxClient";
            this.gbxClient.Size = new System.Drawing.Size(244, 91);
            this.gbxClient.TabIndex = 16;
            this.gbxClient.TabStop = false;
            this.gbxClient.Text = "Client";
            // 
            // btnServerStop
            // 
            this.btnServerStop.Location = new System.Drawing.Point(166, 110);
            this.btnServerStop.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnServerStop.Name = "btnServerStop";
            this.btnServerStop.Size = new System.Drawing.Size(75, 25);
            this.btnServerStop.TabIndex = 12;
            this.btnServerStop.Text = "Stop";
            this.btnServerStop.UseVisualStyleBackColor = true;
            this.btnServerStop.Click += new System.EventHandler(this.btnServerStop_Click);
            // 
            // btnClientDisconnect
            // 
            this.btnClientDisconnect.Location = new System.Drawing.Point(397, 110);
            this.btnClientDisconnect.MinimumSize = new System.Drawing.Size(75, 25);
            this.btnClientDisconnect.Name = "btnClientDisconnect";
            this.btnClientDisconnect.Size = new System.Drawing.Size(95, 25);
            this.btnClientDisconnect.TabIndex = 13;
            this.btnClientDisconnect.Text = "Disconnect";
            this.btnClientDisconnect.UseVisualStyleBackColor = true;
            this.btnClientDisconnect.Click += new System.EventHandler(this.btnClientDisconnect_Click);
            // 
            // gbxMessageHistory
            // 
            this.gbxMessageHistory.Controls.Add(this.tbxMessageHistory);
            this.gbxMessageHistory.Controls.Add(this.tbxMessageToSend);
            this.gbxMessageHistory.Controls.Add(this.btnMessageSend);
            this.gbxMessageHistory.Location = new System.Drawing.Point(513, 13);
            this.gbxMessageHistory.Name = "gbxMessageHistory";
            this.gbxMessageHistory.Size = new System.Drawing.Size(537, 390);
            this.gbxMessageHistory.TabIndex = 17;
            this.gbxMessageHistory.TabStop = false;
            this.gbxMessageHistory.Text = "Message History";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.gbxMessageHistory);
            this.Controls.Add(this.btnClientDisconnect);
            this.Controls.Add(this.btnServerStop);
            this.Controls.Add(this.gbxClient);
            this.Controls.Add(this.gbxServer);
            this.MinimumSize = new System.Drawing.Size(1080, 720);
            this.Name = "FormServer";
            this.Text = "TCP Client";
            this.gbxServer.ResumeLayout(false);
            this.gbxServer.PerformLayout();
            this.gbxClient.ResumeLayout(false);
            this.gbxClient.PerformLayout();
            this.gbxMessageHistory.ResumeLayout(false);
            this.gbxMessageHistory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMessageToSend;
        private System.Windows.Forms.Button btnMessageSend;
        private System.Windows.Forms.TextBox tbxMessageHistory;
        private System.Windows.Forms.TextBox tbxClientIP;
        private System.Windows.Forms.TextBox tbxClientPort;
        private System.Windows.Forms.TextBox tbxServerPort;
        private System.Windows.Forms.TextBox tbxServerIP;
        private System.Windows.Forms.Button btnClientConnect;
        private System.Windows.Forms.Button btnServerStart;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblClientIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblClientPort;
        private System.ComponentModel.BackgroundWorker backgroundWorkerReceiveData;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSendData;
        private System.Windows.Forms.GroupBox gbxServer;
        private System.Windows.Forms.GroupBox gbxClient;
        private System.Windows.Forms.Button btnServerStop;
        private System.Windows.Forms.Button btnClientDisconnect;
        private System.Windows.Forms.GroupBox gbxMessageHistory;
    }
}

