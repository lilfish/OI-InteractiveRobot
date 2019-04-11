using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Proftaak_Server
{
    public partial class FormServer : Form
    {
        private string Receive;
        private string ToSend;
        
        private ServerClient serverClient;

        public FormServer()
        {
            try
            {
                InitializeComponent();
                
                serverClient = new ServerClient();

                tbxServerIP.Text = serverClient.Address;
                btnServerStop.Enabled = false;
                btnClientDisconnect.Enabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void backgroundWorkerReceiveData_DoWork(object sender, DoWorkEventArgs e)
        {
            while (serverClient.IsConnected())
            {
                try
                {
                    Receive = serverClient.ReadIncoming();

                    if (!string.IsNullOrWhiteSpace(Receive))
                    {
                        this.tbxMessageHistory.Invoke(new MethodInvoker(delegate ()
                        {
                            if (serverClient.IsServer)
                            {
                                tbxMessageHistory.AppendText(string.Format("[server]: received [{0}]\n", Receive));
                            }
                            else
                            {
                                tbxMessageHistory.AppendText(string.Format("[client]: received [{0}]\n", Receive));
                            }
                        }));
                    }
                    Receive = "";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void backgroundWorkerSendData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                serverClient.SendOutgoing(ToSend);
                this.tbxMessageHistory.Invoke(new MethodInvoker(delegate ()
                {
                    if (serverClient.IsServer)
                    {
                        tbxMessageHistory.AppendText(string.Format("[server]: send [{0}]\n", ToSend));
                    }
                    else
                    {
                        tbxMessageHistory.AppendText(string.Format("[client]: send [{0}]\n", ToSend));
                    }
                }));
                backgroundWorkerSendData.CancelAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnServerStart_Click(object sender, EventArgs e)
        {
            try
            {
                int port = 0;
                int.TryParse(tbxServerPort.Text, out port);

                Console.WriteLine("Starting server on {0}:{1}", tbxServerIP.Text, port);
                tbxServerIP.Invoke(new MethodInvoker(delegate ()
                {
                    serverClient.StartServerMode(port);
                }));

                string info = string.Format("[server]: Started server on address: {0}:{1}\n", tbxServerIP.Text, port);
                Console.WriteLine(info);
                tbxMessageHistory.AppendText(info);

                backgroundWorkerReceiveData.RunWorkerAsync();
                backgroundWorkerSendData.WorkerSupportsCancellation = true;
                
                gbxClient.Enabled = false;
                btnServerStop.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress address;
                IPAddress.TryParse(tbxClientIP.Text, out address);
                int port = 0;
                int.TryParse(tbxClientPort.Text, out port);

                serverClient.StartClientMode(address, port);

                tbxMessageHistory.AppendText(string.Format("[client]: Connected to server on address: {0}:{1}\n", address, port));

                backgroundWorkerReceiveData.RunWorkerAsync();
                backgroundWorkerSendData.WorkerSupportsCancellation = true;

                gbxServer.Enabled = false;
                btnClientDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnMessageSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tbxMessageToSend.Text))
                {
                    ToSend = tbxMessageToSend.Text;
                    backgroundWorkerSendData.RunWorkerAsync();
                    tbxMessageToSend.Text = "";
                }
                else
                {
                    Console.WriteLine("Check sendbuffer");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnServerStop_Click(object sender, EventArgs e)
        {
            serverClient.StopServerClientMode();
            gbxClient.Enabled = true;
            btnServerStop.Enabled = false;
        }

        private void btnClientDisconnect_Click(object sender, EventArgs e)
        {
            serverClient.StopServerClientMode();
            gbxServer.Enabled = true;
            btnClientDisconnect.Enabled = false;
        }
    }
}
