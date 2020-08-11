using GameBrowser.Clients;
using GameBrowser.Clients.Protocols;
using GameBrowser.Mappers.UnrealTournament99;
using GameBrowser.Models;
using GameBrowser.Models.UnrealTournament99;
using System.Threading.Tasks;

namespace GameBrowser.Managers
{
    public class UT99Manager : IUT99Manager
    {
        private readonly IGamespyClient _serverClient;
        private readonly IPingClient _pingClient;
        private readonly IInfoResponseMapper _infoResponseMapper;

        public UT99Manager(IGamespyClient serverClient, IPingClient pingClient, IInfoResponseMapper infoResponseMapper)
        {
            _serverClient = serverClient;
            _pingClient = pingClient;
            _infoResponseMapper = infoResponseMapper;
        }

        public async Task<ServerInfoDetails> GetInfo(ServerInfoRequest request)
        {
            var pingResponse = await _pingClient.Ping(request.IpAddress);
            var serverResponse = pingResponse.Success ? await _serverClient.GetInfo(request.IpAddress, request.Port) : BuildNullServerResponse();
            var mappedResponse = serverResponse.Success ? _infoResponseMapper.Map(serverResponse.Data) : new ServerInfoDetails { HostName = "Null response" };
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
    }
}
