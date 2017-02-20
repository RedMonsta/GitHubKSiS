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
using System.Threading;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        public string strTime;
        static byte[] sendata = new byte[256];
        static Socket socket;
        static IPEndPoint endPoint;

        private void tmtTime_Tick(object sender, EventArgs e)
        {
            strTime = DateTime.Now.ToString();
            lblTime.Text = strTime;
        }

        private static void Listen()
        {
            //IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            //listeningSocket.Bind(localIP);
        }

        private static void Send()
        {
            while (true)
            {
                Thread.Sleep(10);
                socket.SendTo(sendata, endPoint);
                //EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                //listeningSocket.SendTo(sendata, remotePoint);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //tmtTime.Enabled = true;
            //try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //endPoint = new IPEndPoint(IPAddress.Broadcast, 11000);
                endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                strTime = DateTime.Now.ToString();
                sendata = Encoding.UTF8.GetBytes(strTime);
                socket.Connect(endPoint);
                lblTime.Text = strTime;

                //listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                //Task listeningTask = new Task(Listen);
                //listeningTask.Start();
                Thread sending = new Thread(Send);
                //Task sendTask = new Task(Send);
                //sendTask.Start();
                sending.Start();
            }
            //catch(Exception ex)
            {
                //lblTime.Text = ex.Message;
            }
            //finally
            {
                //Close();
            }
        }
    }
}
