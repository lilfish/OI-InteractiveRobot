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
            this.btn_StartSim = new System.Windows.Forms.Button();
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
            this.btn_Test_RandomPos.Location = new System.Drawing.Point(599, 12);
            this.btn_Test_RandomPos.Name = "btn_Test_RandomPos";
            this.btn_Test_RandomPos.Size = new System.Drawing.Size(189, 31);
            this.btn_Test_RandomPos.TabIndex = 2;
            this.btn_Test_RandomPos.Text = "goToRandom |Pos";
            this.btn_Test_RandomPos.UseVisualStyleBackColor = true;
            this.btn_Test_RandomPos.Click += new System.EventHandler(this.btn_Test_RandomPos_Click);
            // 
            // lbl_debug_text
            // 
            this.lbl_debug_text.AutoSize = true;
            this.lbl_debug_text.Location = new System.Drawing.Point(599, 46);
            this.lbl_debug_text.Name = "lbl_debug_text";
            this.lbl_debug_text.Size = new System.Drawing.Size(74, 17);
            this.lbl_debug_text.TabIndex = 3;
            this.lbl_debug_text.Text = "debug text";
            // 
            // pnl_ControllerSimulation
            // 
            this.pnl_ControllerSimulation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ControllerSimulation.Location = new System.Drawing.Point(153, 12);
            this.pnl_ControllerSimulation.Name = "pnl_ControllerSimulation";
            this.pnl_ControllerSimulation.Size = new System.Drawing.Size(440, 426);
            this.pnl_ControllerSimulation.TabIndex = 4;
            // 
            // btn_StartSim
            // 
            this.btn_StartSim.Location = new System.Drawing.Point(12, 79);
            this.btn_StartSim.Name = "btn_StartSim";
            this.btn_StartSim.Size = new System.Drawing.Size(135, 31);
            this.btn_StartSim.TabIndex = 5;
            this.btn_StartSim.Text = "Start Sim";
            this.btn_StartSim.UseVisualStyleBackColor = true;
            this.btn_StartSim.Click += new System.EventHandler(this.btn_StartSim_Click);
            // 
            // Form_MovingHead_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_StartSim);
            this.Controls.Add(this.pnl_ControllerSimulation);
            this.Controls.Add(this.lbl_debug_text);
            this.Controls.Add(this.btn_Test_RandomPos);
            this.Controls.Add(this.cbx_COM_PORTS);
            this.Controls.Add(this.btn_SerialConnect);
            this.Name = "Form_MovingHead_Demo";
            this.Text = "MovingHead_Demo";
            this.Load += new System.EventHandler(this.Form_MovingHead_Demo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_SerialConnect;
        private System.Windows.Forms.ComboBox cbx_COM_PORTS;
        private System.Windows.Forms.Button btn_Test_RandomPos;
        private System.Windows.Forms.Label lbl_debug_text;
        private System.Windows.Forms.Panel pnl_ControllerSimulation;
        private System.Windows.Forms.Button btn_StartSim;
    }
}

