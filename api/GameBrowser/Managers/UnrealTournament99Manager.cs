using GameBrowser.Clients;
using GameBrowser.Clients.Games;
using GameBrowser.Mappers.UnrealTournament99;
using GameBrowser.Models;
using GameBrowser.Models.UnrealTournament99;
using System.Threading.Tasks;

namespace GameBrowser.Managers
{
    public class UnrealTournament99Manager : IUnrealTournament99Manager
    {
        private readonly IUnrealTournament99GameClient _serverClient;
        private readonly IPingClient _pingClient;
        private readonly IInfoResponseMapper _infoResponseMapper;

        public UnrealTournament99Manager(IUnrealTournament99GameClient serverClient, IPingClient pingClient, IInfoResponseMapper infoResponseMapper)
        {
            _serverClient = serverClient;
            _pingClient = pingClient;
            _infoResponseMapper = infoResponseMapper;
        }

        public async Task<ServerInfoDetails> GetInfo(ServerRequest request)
        {
            var pingResponse = await _pingClient.Ping(request.IpAddress);
            var serverResponse = pingResponse.Success ? await _serverClient.GetInfo(request.IpAddress, request.Port) : BuildNullServerResponse();
            var mappedResponse = serverResponse.Success ? _infoResponseMapper.Map(serverResponse.Data) : new ServerInfoDetails { HostName = "Null response" };
            mappedResponse.Ping = pingResponse.Milliseconds;
            return mappedResponse;
        }

        private ServerResponse BuildNullServerResponse()
        {
            return new ServerResponse
            {
                Data = string.Empty,
                Error = "Error in response",
                Success = false
            };
        }
    }
}
