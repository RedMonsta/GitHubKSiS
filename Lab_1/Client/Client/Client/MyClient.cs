using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class MyClient
    {
        public MyClient(int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint localIP = new IPEndPoint(GetLocalIPAddress(), port);
            socket.Bind(localIP);
        }
        private IPAddress GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ipaddr in host.AddressList)
            {
                if (ipaddr.AddressFamily == AddressFamily.InterNetwork) return ipaddr;
            }
            throw new Exception("Local IP Address Not Found!");
        }
        public string ReceiveData()
        {
            byte[] data = new byte[256];
            string str = "";

            if (socket.Available > 0)
            {
                socket.Receive(data);
                str += Encoding.ASCII.GetString(data);
            }

            return str;
        }

        private Socket socket { get; set; }
        private IPEndPoint localIP { get; set; }

    }
}
