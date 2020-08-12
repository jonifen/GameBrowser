using GameBrowser.Models;
using GameBrowser.Models.UdpServerClient;
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
            var originalCommandBytes = Encoding.ASCII.GetBytes(command);
            var result = new byte[originalCommandBytes.Length + 5];

            // Build the first 4 characters (ÿÿÿÿ)
            // For some reason the characters aren't parsed properly if built as string?
            result[0] = byte.Parse("255");
            result[1] = byte.Parse("255");
            result[2] = byte.Parse("255");
            result[3] = byte.Parse("255");

            var bufferIndex = 4;

            for (int i = 0; i < originalCommandBytes.Length; i++)
            {
                result[bufferIndex] = originalCommandBytes[i];
                bufferIndex++;
            }

            return result;
        }
    }
}
