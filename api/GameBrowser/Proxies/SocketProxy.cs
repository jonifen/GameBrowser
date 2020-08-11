using System.Net;
using System.Net.Sockets;

namespace GameBrowser.Proxies
{
    public class SocketProxy : ISocketProxy
    {
        private readonly Socket _socket;

        public SocketProxy() : this(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        {
        }

        public SocketProxy(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
        {
            _socket = new Socket(addressFamily, socketType, protocolType);
        }

        public SocketProxy(Socket socket)
        {
            _socket = socket;
        }

        public ISocketProxy Accept()
        {
            return new SocketProxy(_socket.Accept());
        }

        public void Bind(IPEndPoint localEP)
        {
            _socket.Bind(localEP);
        }

        public void Close()
        {
            _socket.Close();
        }

        public void Connect(IPAddress address, int port)
        {
            _socket.Connect(address, port);
        }

        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }

        public int Receive(byte[] buffer)
        {
            return _socket.Receive(buffer);
        }

        public void Send(byte[] buffer, SocketFlags socketFlags)
        {
            _socket.Send(buffer, socketFlags);
        }
    }
}
