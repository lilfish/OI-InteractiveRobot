namespace MH_Control
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.BT_SerialConnect = new System.Windows.Forms.Button();
            this.cb_COM_PORTS = new System.Windows.Forms.ComboBox();
            this.BTN_Test_RandomPOS = new System.Windows.Forms.Button();
            this.Timer_1 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BT_SerialConnect
            // 
            this.BT_SerialConnect.Location = new System.Drawing.Point(12, 12);
            this.BT_SerialConnect.Name = "BT_SerialConnect";
            this.BT_SerialConnect.Size = new System.Drawing.Size(135, 31);
            this.BT_SerialConnect.TabIndex = 0;
            this.BT_SerialConnect.Text = "SerialConnect";
            this.BT_SerialConnect.UseVisualStyleBackColor = true;
            this.BT_SerialConnect.Click += new System.EventHandler(this.BT_SerialConnect_Click);
            // 
            // cb_COM_PORTS
            // 
            this.cb_COM_PORTS.FormattingEnabled = true;
            this.cb_COM_PORTS.Location = new System.Drawing.Point(12, 49);
            this.cb_COM_PORTS.Name = "cb_COM_PORTS";
            this.cb_COM_PORTS.Size = new System.Drawing.Size(135, 24);
            this.cb_COM_PORTS.TabIndex = 1;
            // 
            // BTN_Test_RandomPOS
            // 
            this.BTN_Test_RandomPOS.Location = new System.Drawing.Point(294, 12);
            this.BTN_Test_RandomPOS.Name = "BTN_Test_RandomPOS";
            this.BTN_Test_RandomPOS.Size = new System.Drawing.Size(189, 31);
            this.BTN_Test_RandomPOS.TabIndex = 2;
            this.BTN_Test_RandomPOS.Text = "goToRandom |Pos";
            this.BTN_Test_RandomPOS.UseVisualStyleBackColor = true;
            this.BTN_Test_RandomPOS.Click += new System.EventHandler(this.BTN_Test_RandomPOS_Click);
            // 
            // Timer_1
            // 
            this.Timer_1.Tick += new System.EventHandler(this.Timer_1_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Test_RandomPOS);
            this.Controls.Add(this.cb_COM_PORTS);
            this.Controls.Add(this.BT_SerialConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_SerialConnect;
        private System.Windows.Forms.ComboBox cb_COM_PORTS;
        private System.Windows.Forms.Button BTN_Test_RandomPOS;
        private System.Windows.Forms.Timer Timer_1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

