using GameBrowser.Clients.Protocols;
using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Games
{
    public class UnrealTournament99GameClient : IUnrealTournament99GameClient
    {
        private readonly IGamespyClient _gamespyClient;

        public UnrealTournament99GameClient(IGamespyClient gamespyClient)
        {
            _gamespyClient = gamespyClient;
        }

        public Task<ServerResponse> GetInfo(string ipAddress, int port)
        {
            return _gamespyClient.GetInfo(ipAddress, port);
        }

        public Task<ServerResponse> GetPlayers(string ipAddress, int port)
        {
            return _gamespyClient.GetPlayers(ipAddress, port);
        }

        public Task<ServerResponse> GetRules(string ipAddress, int port)
        {
            return _gamespyClient.GetRules(ipAddress, port);
        }

        public Task<ServerResponse> GetStatus(string ipAddress, int port)
        {
            return _gamespyClient.GetStatus(ipAddress, port);
        }
    }
}
