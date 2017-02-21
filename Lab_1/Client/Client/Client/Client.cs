using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            client = new MyClient(10000);
        }

        private MyClient client { get; set; }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            string strdata = client.ReceiveData();
            if (strdata.Length > 0) lblData.Text = strdata;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            tmrTime.Enabled = true;
        }
    }
}
