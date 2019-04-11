using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Proftaak_Server
{
    class ServerClient
    {
        private TcpClient client;
        private StreamReader StrmReader;
        private StreamWriter StrmWriter;

        public bool IsServer { get; private set; }
        public string Address { get; private set; }

        public ServerClient()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress item in localIP)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    Address = item.ToString();
                }
            }
        }

        public bool IsConnected()
        {
            return client.Connected;
        }

        public string ReadIncoming()
        {
            return StrmReader.ReadLine();
        }

        public void SendOutgoing(string message)
        {
            if (IsConnected())
            {
                StrmWriter.WriteLine(message);
            }
            else
            {
                throw new ConnectionException("Failed to send, please check connection");
            }
        }

        public void StartServerMode(int port)
        {
            if (port <= 0)
            {
                throw new ArgumentOutOfRangeException("Check port, value may not be equal to or less then 0");
            }

            IsServer = true;
            
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            client = listener.AcceptTcpClient();
            StrmReader = new StreamReader(client.GetStream());
            StrmWriter = new StreamWriter(client.GetStream());
            StrmWriter.AutoFlush = true;

        }

        public void StartClientMode(IPAddress address, int port)
        {
            if (address == null)
            {
                throw new ArgumentNullException("Check ip, address was resolved to null");
            }

            IsServer = false;

            client = new TcpClient();
            IPEndPoint endPoint = new IPEndPoint(address, port);

            client.Connect(endPoint);
            if (IsConnected())
            {
                StrmReader = new StreamReader(client.GetStream());
                StrmWriter = new StreamWriter(client.GetStream());
                StrmWriter.AutoFlush = true;
            }
        }

        public void StopServerClientMode()
        {
            client.Close();
            StrmReader.Close();
            StrmWriter.Close();
        }

    }
}
