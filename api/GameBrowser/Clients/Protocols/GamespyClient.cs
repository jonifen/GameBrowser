using GameBrowser.Models;
using GameBrowser.Models.UdpServerClient;
using System.Text;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Protocols
{
    public class GamespyClient : IGamespyClient
    {
        private readonly IUdpServerClient _udpClient;

        public GamespyClient(IUdpServerClient udpServerClient)
        {
            _udpClient = udpServerClient;
        }

        public async Task<ServerResponse> GetStatus(string ipAddress, int port)
        {
            return await MakeRequest(ipAddress, port, "\\status\\");
        }

        public async Task<ServerResponse> GetInfo(string ipAddress, int port)
        {
            return await MakeRequest(ipAddress, port, "\\info\\");
        }

        public async Task<ServerResponse> GetRules(string ipAddress, int port)
        {
            return await MakeRequest(ipAddress, port, "\\rules\\");
        }

        public async Task<ServerResponse> GetPlayers(string ipAddress, int port)
        {
            return await MakeRequest(ipAddress, port, "\\players\\");
        }

        private async Task<ServerResponse> MakeRequest(string ipAddress, int port, string command)
        {
            var request = new Request
            {
                IpAddress = ipAddress,
                Port = port,
                Payload = Encoding.ASCII.GetBytes(command)
            };

            var response = await _udpClient.GetData(request);

            return new ServerResponse
            {
                Data = response.Payload,
                Success = response.Success,
                Error = response.Error
            };
        }
    }
}
