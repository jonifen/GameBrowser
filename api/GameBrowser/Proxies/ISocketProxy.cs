using System.Net;
using System.Net.Sockets;

namespace GameBrowser.Proxies
{
    public interface ISocketProxy
    {
        void Close();
        void Connect(IPAddress address, int port);
        int Receive(byte[] buffer);
        void Send(byte[] buffer, SocketFlags socketFlags);
        void Listen(int backlog);
        void Bind(IPEndPoint localEP);
    }
}