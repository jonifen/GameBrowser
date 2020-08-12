using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Games
{
    public interface IUnrealTournament99GameClient
    {
        Task<ServerResponse> GetInfo(string ipAddress, int port);
        Task<ServerResponse> GetPlayers(string ipAddress, int port);
        Task<ServerResponse> GetRules(string ipAddress, int port);
        Task<ServerResponse> GetStatus(string ipAddress, int port);
    }
}
