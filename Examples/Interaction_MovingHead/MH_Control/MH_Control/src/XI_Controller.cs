using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.XInput;

namespace MH_Control
{
    class XI_Controller
    {
        Controller controller;
        Gamepad gamepad;
        public bool connected = false;
        public int deadband = 2500;
        public Point leftThumb, rightThumb = new Point(0, 0);
        public float leftTrigger, rightTrigger;
        public GamepadButtonFlags Buttons;

        public XI_Controller()
        {
               controller = new Controller(UserIndex.One);
            connected = controller.IsConnected;
        }

        public void Update()
        {
            if (!connected)  return;

            gamepad = controller.GetState().Gamepad;

            leftThumb.X = gamepad.LeftThumbX;
            leftThumb.Y = gamepad.LeftThumbY;
            rightThumb.X = gamepad.RightThumbX;
            rightThumb.Y = gamepad.RightThumbY;
            Buttons = gamepad.Buttons;

            leftTrigger = gamepad.LeftTrigger;
            rightTrigger = gamepad.RightTrigger;
        }

    }
}
