using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;


namespace MH_Control
{
    public partial class Form_MovingHead_Demo : Form
    {
        const int thumbStickMax = 32668;
        const int thumbStickMin = -32668;
        const int panMin = 95;
        const int panMax = 159;
        const int tiltMin = 8;
        const int tiltMax = 127;

        public Random r;
        IMovinghead Movinghead;
        XI_Controller controller;

        Timer timer_main;
        Timer timer_timeOut;

        bool toggleLED = false;
        bool timeout = false;
        bool simulation = false;

        private void CheckPorts()
        {
            cbx_COM_PORTS.Items.AddRange(SerialPort.GetPortNames());
            lbl_debug_text.Text = "Ports found: " + cbx_COM_PORTS.Items.Count;
            if (cbx_COM_PORTS.Items.Count > 0)
            {
                cbx_COM_PORTS.SelectedIndex = 0;
                simulation = false;
                btn_StartSim.Enabled = false;
            }
            else
            {
                cbx_COM_PORTS.Text = "No Ports found";
                btn_SerialConnect.Enabled = false;
                lbl_debug_text.Text += "\nSwitching to simulation mode";
                simulation = true;
                btn_StartSim.Enabled = true;
            }
        }

        private int Map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            int calculated = (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
            return calculated;
        }

        public Form_MovingHead_Demo()
        {
            InitializeComponent();
        }

        private void Form_MovingHead_Demo_Load(object sender, EventArgs e)
        {
            timer_main = new Timer();
            timer_main.Tick += new EventHandler(timer_main_Tick);
            timer_timeOut = new Timer();
            timer_timeOut.Tick += new EventHandler(timer_timeout_Tick);
            timer_main.Interval = 50;
            timer_timeOut.Interval = 200;

            CheckPorts();
            r = new Random(DateTime.Today.Millisecond);
            controller = new XI_Controller();
            controller.Update();

            btn_Test_RandomPos.Enabled = false;
        }

        private void btn_SerialConnect_Click(object sender, EventArgs e)
        {
            if(cbx_COM_PORTS.SelectedItem == null)
            {
                MessageBox.Show("select Serial port");
                return;
            }

            Movinghead = new MH_Showtec25LED(cbx_COM_PORTS.SelectedItem.ToString(), 9600, 1);
            timer_main.Start();

        }

        private void btn_StartSim_Click(object sender, EventArgs e)
        {
            timer_main.Start();

        }

        private void btn_Test_RandomPos_Click(object sender, EventArgs e)
        {
            Movinghead.Move(r.Next(0,255), r.Next(0, 255));
            Movinghead.Strobe(r.Next(0, 255));
            Movinghead.Color(r.Next(0, 255));
            Movinghead.Dimmer(r.Next(0, 255));

        }

        private void timer_main_Tick(object sender, EventArgs e)
        {
            int pan = 0;
            int tilt = 0;
            int pan_Scoped = 0;
            int tilt_Scoped = 0;
            int Rtrigger = 0;
            int Ltrigger = 0;

            if (!simulation)
            {
                controller.Update();

                pan = controller.leftThumb.X + r.Next(-2048, 2048);
                tilt = controller.leftThumb.Y + r.Next(-1024, 0);
                pan_Scoped = Map(pan, thumbStickMax, thumbStickMin, panMin, panMax);
                tilt_Scoped = Map(tilt, thumbStickMin, thumbStickMax, tiltMin, tiltMax);

                Rtrigger = (int)controller.rightTrigger;
                Ltrigger = (int)controller.leftTrigger;

                switch (controller.Buttons)
                {
                    case GamepadButtonFlags.None:
                        break;
                    case GamepadButtonFlags.DPadUp:
                        break;
                    case GamepadButtonFlags.DPadDown:
                        break;
                    case GamepadButtonFlags.DPadLeft:
                        break;
                    case GamepadButtonFlags.DPadRight:
                        break;
                    case GamepadButtonFlags.Start:
                        break;
                    case GamepadButtonFlags.Back:
                        break;
                    case GamepadButtonFlags.LeftThumb:
                        break;
                    case GamepadButtonFlags.RightThumb:
                        break;
                    case GamepadButtonFlags.LeftShoulder:
                        Movinghead.Color(0);
                        break;
                    case GamepadButtonFlags.RightShoulder:
                        if (!timeout)
                        {
                            if (toggleLED)
                            {
                                Movinghead.Strobe(255);
                                Movinghead.Dimmer(1);
                                toggleLED = false;
                            }
                            else
                            {
                                Movinghead.Strobe(0);
                                Movinghead.Dimmer(0);
                                toggleLED = true;
                            }
                            timeout = true;
                            timer_timeOut.Start();
                        }
                        break;
                    case GamepadButtonFlags.A:
                        Movinghead.Color(20);
                        break;
                    case GamepadButtonFlags.B:
                        Movinghead.Color(26);
                        break;
                    case GamepadButtonFlags.X:
                        Movinghead.Color(45);
                        break;
                    case GamepadButtonFlags.Y:
                        Movinghead.Color(38);
                        break;
                    default:
                        Movinghead.Color(0);
                        Movinghead.Strobe(0);
                        Movinghead.Dimmer(0);
                        break;
                }

                // 127 == 0;

                if (pan_Scoped < 256 && pan_Scoped >= 0 && tilt_Scoped < 256 && tilt_Scoped >= 0)
                {
                    Movinghead.Move(pan_Scoped, tilt_Scoped);
                }
            }
            else
            {
                int x1 = pnl_ControllerSimulation.Location.X;
                int x2 = x1 + pnl_ControllerSimulation.Width;
                int y1 = pnl_ControllerSimulation.Location.Y;
                int y2 = y1 + pnl_ControllerSimulation.Height;
                Point pos = PointToClient(MousePosition);
                if (pos.X > x1 && pos.X < x2 && pos.Y > y1 && pos.Y < y2)
                {
                    pan = Map(pos.X, x1, x2, -256, 256);
                    tilt = Map(pos.Y, y2, y1, -256, 256);
                    pan_Scoped = Map(pan, -256, 256, panMin, panMax);
                    tilt_Scoped = Map(tilt, -256, 256, tiltMin, tiltMax);
                }
            }

            string output = "Raw: pan:" + pan + "\n\ttilt:" + tilt + "\nMapped: pan:" + pan_Scoped + "\n\ttilt:" + tilt_Scoped;
            lbl_debug_text.Text = output;
            Console.WriteLine(output);

        }

        private void timer_timeout_Tick(object sender, EventArgs e)
        {
            timer_timeOut.Stop();
            timeout = false;
        }
    }
}
