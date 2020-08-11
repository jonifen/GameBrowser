using GameBrowser.Clients;
using GameBrowser.Mappers.Quake3;
using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBrowser.Managers
{
    public class Q3AManager : IQ3AManager
    {
        private readonly IQ3AServerClient _q3aServerClient;
        private readonly IPingClient _pingClient;
        private readonly IServerResponseMapper _q3aServerResponseMapper;

        public Q3AManager(IQ3AServerClient q3aServerClient, IPingClient pingClient, IServerResponseMapper q3aServerResponseMapper)
        {
            _q3aServerClient = q3aServerClient;
            _pingClient = pingClient;
            _q3aServerResponseMapper = q3aServerResponseMapper;
        }

        public async Task<ServerDetails> GetServerDetails(ServerInfoRequest request)
        {
            var pingResponse = await _pingClient.Ping(request.IpAddress);
            var serverResponse = pingResponse.Success ? _q3aServerClient.GetStatus(request.IpAddress, request.Port) : BuildNullServerResponse();

            var mappedResponse = serverResponse.Success ? _q3aServerResponseMapper.Map(serverResponse.Data) : BuildNullServerDetails();
            mappedResponse.IpAddress = request.IpAddress;
            mappedResponse.Port = request.Port;
            mappedResponse.Ping = pingResponse.Milliseconds;
            return mappedResponse;
        }

        private ServerInfoResponse BuildNullServerResponse()
        {
            return new ServerInfoResponse
            {
                Data = string.Empty,
                Error = "Error in response",
                Success = false
            };
        }

        private ServerDetails BuildNullServerDetails()
        {
            return new ServerDetails
            {
                Name = "Unknown",
                Players = new List<Player>(),
                AllDetails = new Dictionary<string, string>(),
                Ping = 9999
            };
        }
    }
}
