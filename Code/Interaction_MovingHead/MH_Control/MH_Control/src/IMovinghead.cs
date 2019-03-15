using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Control
{ 

    interface IMovinghead
    {
        void SetAdress(int adress);


        void Move(int pan, int tilt);
        void Move(int pan, int tilt, int speed);

        void MoveFine(int pan, int tilt);
        void MoveFine(int pan, int tilt, int speed);


        void Strobe(int effect);

        void Dimmer(int intensity);

        void Color(int color);

        void Control(int setting);

        void Reset();



    }
}
