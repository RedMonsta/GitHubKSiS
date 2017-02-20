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

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        public string strTime;
        static byte[] recdata = new byte[256];
        static Socket socket;
        static int bytes;
        static IPEndPoint endPoint;
        static EndPoint endp;

        private static void Rec()
        {
            while (true)
            {
                //Thread.Sleep(10);
                socket.Receive(recdata);
                //EndPoint remotePoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                //listeningSocket.SendTo(sendata, remotePoint);
                bytes = socket.ReceiveFrom(recdata, ref endp);
                
            }
        }

        // private byte[] bytes = new byte[1024];

        private void btnConnect_Click(object sender, EventArgs e)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            endp = endPoint as EndPoint;
            socket.Connect(endPoint);

            //Task RecTask = new Task(Rec);
            //RecTask.Start();
            Thread rec = new Thread(Rec);
            rec.Start();
            lblData.Text = Encoding.ASCII.GetString(recdata, 0, bytes);

            //int bytesRec = sSender.Receive(bytes);
            //lblData.Text = Encoding.ASCII.GetString(bytes, 0, bytesRec);


        }
    }
}
