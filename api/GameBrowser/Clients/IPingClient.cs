using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients
{
    public interface IPingClient
    {
        Task<PingResponse> Ping(string ipAddress);
    }
}