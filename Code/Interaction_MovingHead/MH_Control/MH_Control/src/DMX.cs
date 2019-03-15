using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Control
{
    class DMX
    {
        private static SerialPort serialPort;

        // Serial to DMX system:
        public static bool IsOpen { get; private set; }

  
        
        public static void OpenCOM(string SERIAL_COM, int SERIAL_bautRate, int DMX_adress )
        {
            if (IsOpen) throw new InvalidOperationException("COM is still OPEN");

            if (SERIAL_COM == null) throw new ArgumentNullException("SERIAL_COM");
            if (SERIAL_bautRate < 1200) throw new ArgumentOutOfRangeException("SERIAL_bautRate");
            if (DMX_adress < 1) throw new ArgumentOutOfRangeException("DMX_adress");

            serialPort = new SerialPort(SERIAL_COM, SERIAL_bautRate);

            serialPort.Open();
            if (!serialPort.IsOpen) throw new ArgumentException("Port Cant OPEN");

            IsOpen = true;
         
        }

   
        public void CloseCOM()
        {
            if (!IsOpen) return;

            serialPort.Close();
            IsOpen = false;
            serialPort.Dispose();
        }

        public static void Send(byte channel, int value)
        {
            string message = channel.ToString() + " " + value.ToString();
            serialPort.WriteLine(message);
        }
    }
}
