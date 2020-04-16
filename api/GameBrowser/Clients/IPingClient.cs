using GameBrowser.Models;

namespace GameBrowser.Clients
{
    public interface IPingClient
    {
        PingResponse Ping(string ipAddress);
    }
}