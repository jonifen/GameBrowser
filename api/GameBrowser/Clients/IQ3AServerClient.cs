using GameBrowser.Models;

namespace GameBrowser.Clients
{
    public interface IQ3AServerClient
    {
        ServerInfoResponse GetInfo(string ipAddress, int port);
        ServerInfoResponse GetStatus(string ipAddress, int port);
    }
}