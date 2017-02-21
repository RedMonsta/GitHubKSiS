using System;
using System.Windows.Forms;
using System.Net;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            servak = new MyServer(IPAddress.Broadcast, 10000);
        }

        private MyServer servak { get; set; }
        private string strTime;

        private void tmtTime_Tick(object sender, EventArgs e)
        {
            strTime = DateTime.Now.ToString();
            lblTime.Text = strTime;
            servak.SendData(strTime);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmtTime.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmtTime.Enabled = false;
        }
    }
}
