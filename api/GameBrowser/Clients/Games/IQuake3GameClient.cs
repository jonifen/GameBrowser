using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Games
{
    public interface IQuake3GameClient
    {
        Task<ServerResponse> GetInfo(string ipAddress, int port);
        Task<ServerResponse> GetStatus(string ipAddress, int port);
    }
}
