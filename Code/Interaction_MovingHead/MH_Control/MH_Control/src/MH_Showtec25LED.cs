using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Control
{
    class MH_Showtec25LED : IMovinghead
    {
        // Only showing implemented functions of the movinghead:
        //
        /*  DMX PRotocol 11 Channels
         *  CH1:    horizontal movement (Pan)                   : 540* (0-255, 128 center).
         *  CH2:    Vertical movement (Tilt )                   : 16 bits.
         *  CH3:    horizontal movement fine (Pan)              : 540* (0-255, 128 center).
         *  CH4:    Vertical movement fine (Tilt )              : 16 bits.
         *  CH5:    Pan/Tilt speed                              : 0-255 where 255 is min speed.
         *  CH6:    Colorwheel                                  : 0-5       White.              
         *                                                      : 6-11      Yellow.
         *                                                      : 18-23     Green.
         *                                                      : 24-29     Red.
         *                                                   X  : 30-35     Ligh blue.
         *                                                      : 36-41     Orange.
         *                                                      : 42-47     Dark Blue.
         *                                                   X  : 48-53     Light green.
         *                                                   X  : 54-63     Bright red.
         * CH7:     Shutter                                     : 0-3       Closed.
         *                                                      : 4-7       Open.
         *                                                      : 8-215     Strobe.
         *                                                      : 216-255   Open.
         * CH8:     Dimmer                                      : 0-255     from black to brightest .
         * CH10:    Channel Functions                           : 0-7       No function.
         *                                                      : 148-167   Reset Pan.
         *                                                      : 168-187   Reset Tilt.
         *                                                      : 228-247   Reset all Channels.
         * 
         */

        private byte DMX_adress;


        public MH_Showtec25LED(String COM, int baud,  byte DMX_Adress)
        {
            DMX_adress = DMX_Adress;
            if(!DMX.IsOpen)
            {
                DMX.OpenCOM(COM, baud, DMX_Adress);
            }
        }

        public void Move(int pan, int tilt)
        {
            if (pan < 0 || pan > 255) throw new ArgumentOutOfRangeException("pan");
            if (tilt < 0 || tilt > 255) throw new ArgumentOutOfRangeException("tilt");
            DMX.Send(1, pan);
            DMX.Send(2, tilt);

        }

        public void Move(int pan, int tilt, int speed)
        {
            if (pan < 0 || pan > 255) throw new ArgumentOutOfRangeException("pan");
            if (tilt < 0 || tilt > 255) throw new ArgumentOutOfRangeException("tilt");
            if (speed < 0 || speed > 255) throw new ArgumentOutOfRangeException("speed");
            DMX.Send(1, pan);
            DMX.Send(2, tilt);
            DMX.Send(5, speed);
        }

        public void MoveFine(int pan, int tilt)
        {
            if (pan < 0 || pan > 255) throw new ArgumentOutOfRangeException("pan");
            if (tilt < 0 || tilt > 255) throw new ArgumentOutOfRangeException("tilt");
            DMX.Send(3, pan);
            DMX.Send(4, tilt);
        }

        public void MoveFine(int pan, int tilt, int speed)
        {
            if (pan < 0 || pan > 255) throw new ArgumentOutOfRangeException("pan");
            if (tilt < 0 || tilt > 255) throw new ArgumentOutOfRangeException("tilt");
            if (speed < 0 || speed > 255) throw new ArgumentOutOfRangeException("speed");
            DMX.Send(3, pan);
            DMX.Send(4, tilt);
            DMX.Send(5, speed);
        }

        public void Color(int color)
        {
            if (color < 0 || color > 255) throw new ArgumentOutOfRangeException("color");
            DMX.Send(6, color);
        }

        public void Control(int setting)
        {
            if (setting < 0 || setting > 255) throw new ArgumentOutOfRangeException("setting");
            DMX.Send(10, setting);
        }

        public void Dimmer(int intensity)
        {
            if (intensity < 0 || intensity > 255) throw new ArgumentOutOfRangeException("intensity");
            DMX.Send(8, intensity);
        } 

        public void Strobe(int effect)
        {
            if (effect < 0 || effect > 255) throw new ArgumentOutOfRangeException("effect");
            DMX.Send(7, effect);
        }

        public void SetAdress(int adress)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            DMX.Send(10, 228);
        }
    }
}

