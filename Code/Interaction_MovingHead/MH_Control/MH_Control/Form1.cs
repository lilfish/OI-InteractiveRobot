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
    public partial class Form1 : Form
    {
        private IMovinghead Movinghead;
        public Random r;
        private XI_Controller controller;

        int pos_x;
        int pos_y;

        public Form1()
        {
            
            InitializeComponent();
  
            cb_COM_PORTS.Items.AddRange(SerialPort.GetPortNames());
            r = new Random(134);
            controller = new XI_Controller();
            controller.Update();

            pos_x = 127;
            pos_y = 127;

        }

        private int Map(int x, int in_min, int in_max)
        {
            int calculated = (x - in_min) * (255 - 0) / (in_max - in_min) + 0;
            return calculated;
        }

        private void BT_SerialConnect_Click(object sender, EventArgs e)
        {
            if(cb_COM_PORTS.SelectedItem == null)
            {
                MessageBox.Show("select Serial port");
                return;
            }

            Movinghead = new MH_Showtec25LED(cb_COM_PORTS.SelectedItem.ToString(), 9600, 1);
            timer1.Start();


        }

        private void BTN_Test_RandomPOS_Click(object sender, EventArgs e)
        {
            Movinghead.Move(r.Next(0,255), r.Next(0, 255));
            Movinghead.Strobe(r.Next(0, 255));
            Movinghead.Color(r.Next(0, 255));
            Movinghead.Dimmer(r.Next(0, 255));
            

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            controller.Update();

            int X = controller.leftThumb.X + 0;
            int Y = controller.leftThumb.Y + 0;
            int Rtrigger = (int)controller.rightTrigger;
            int Ltrigger = (int)controller.leftTrigger;

            int X_Scoped = Map(X, -32668, 32668);
            int Y_Scoped = Map(Y, -32668, 32668);

           // 127 == 0;

            if (X_Scoped < 80) pos_x = pos_x + 3;
            if (X_Scoped > 170) pos_x = pos_x - 3;

            if (Y_Scoped < 80) pos_y = pos_y - 3;
            if (Y_Scoped > 170) pos_y = pos_y + 3;


            if (pos_x > 255)    pos_x = 255;
            if (pos_x < 0)      pos_x = 0;

            if (pos_y > 255)    pos_y = 255;
            if (pos_y < 0)      pos_y = 0;

            //Movinghead.MoveFine(pos_x, pos_y);
            Movinghead.Move(pos_x, pos_y,0);

            Movinghead.Strobe(Rtrigger);
            Movinghead.Dimmer(Ltrigger);
            if(controller.Buttons == GamepadButtonFlags.A)
            {
                Movinghead.Color(20);
            }
            else
            {
                Movinghead.Color(0);
            }


            


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
 

        }

        private void Timer_1_Tick(object sender, EventArgs e)
        {

        }
    }
}
