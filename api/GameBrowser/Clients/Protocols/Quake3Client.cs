using GameBrowser.Models;
using GameBrowser.Models.UdpServerClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Protocols
{
    public class Quake3Client : IQuake3Client
    {
        private readonly IUdpServerClient _udpClient;

        public Quake3Client(IUdpServerClient udpServerClient)
        {
            _udpClient = udpServerClient;
        }

        public async Task<ServerResponse> GetStatus(string ipAddress, int port)
        {
            return await MakeRequest(ipAddress, port, "getstatus");
        }

        public async Task<ServerResponse> GetInfo(string ipAddress, int port)
        {
            return await MakeRequest(ipAddress, port, "getinfo");
        }

        private async Task<ServerResponse> MakeRequest(string ipAddress, int port, string command)
        {
            var request = new Request
            {
                IpAddress = ipAddress,
                Port = port,
                Payload = BuildPayload(command)
            };

            var response = await _udpClient.GetData(request);

            return new ServerResponse
            {
                Data = response.Payload,
                Success = response.Success,
                Error = response.Error
            };
        }

        private byte[] BuildPayload(string command)
        {
            var commandBytes = Encoding.ASCII.GetBytes(command);

            // Build the first 4 characters (ÿÿÿÿ)
            var prefix = new byte[] { 255, 255, 255, 255 };

            var firstStep = prefix.Concat(commandBytes);

            return firstStep.Concat(new byte[] { 0 }).ToArray();
        }
    }
}
