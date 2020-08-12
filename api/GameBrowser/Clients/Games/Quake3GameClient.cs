using GameBrowser.Clients.Protocols;
using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Games
{
    public class Quake3GameClient : IQuake3GameClient
    {
        private readonly IQuake3Client _quake3Client;

        public Quake3GameClient(IQuake3Client quake3Client)
        {
            _quake3Client = quake3Client;
        }

        public Task<ServerResponse> GetInfo(string ipAddress, int port)
        {
            return _quake3Client.GetInfo(ipAddress, port);
        }

        public Task<ServerResponse> GetStatus(string ipAddress, int port)
        {
            return _quake3Client.GetStatus(ipAddress, port);
        }
    }
}
