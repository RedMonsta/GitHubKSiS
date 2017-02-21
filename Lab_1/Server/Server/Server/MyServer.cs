using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class MyServer
    {
        public MyServer(IPAddress ipAddress, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.EnableBroadcast = true;
            endPoint = new IPEndPoint(ipAddress, port);
        }

        private Socket socket { get; set; }
        private IPEndPoint endPoint { get; set; }

        public void SendData(string Message)
        {
            socket.SendTo(Encoding.UTF8.GetBytes(Message), endPoint);
        }
    }
}
