using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Protocols
{
    public interface IGamespyClient
    {
        Task<ServerInfoResponse> GetInfo(string ipAddress, int port);
        Task<ServerInfoResponse> GetPlayers(string ipAddress, int port);
        Task<ServerInfoResponse> GetRules(string ipAddress, int port);
        Task<ServerInfoResponse> GetStatus(string ipAddress, int port);
    }
}