using GameBrowser.Clients;
using GameBrowser.Clients.Games;
using GameBrowser.Mappers.Quake3;
using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameBrowser.Managers
{
    public class Quake3Manager : IQuake3Manager
    {
        private readonly IQuake3GameClient _gameClient;
        private readonly IPingClient _pingClient;
        private readonly IStatusResponseMapper _q3aServerResponseMapper;

        public Quake3Manager(IQuake3GameClient quake3GameClient, IPingClient pingClient, IStatusResponseMapper q3aServerResponseMapper)
        {
            _gameClient = quake3GameClient;
            _pingClient = pingClient;
            _q3aServerResponseMapper = q3aServerResponseMapper;
        }

        public async Task<ServerStatusDetails> GetStatus(ServerRequest request)
        {
            var pingResponse = await _pingClient.Ping(request.IpAddress);
            var serverResponse = pingResponse.Success ? await _gameClient.GetStatus(request.IpAddress, request.Port) : BuildNullServerResponse();

            var mappedResponse = serverResponse.Success ? _q3aServerResponseMapper.Map(serverResponse.Data) : BuildNullServerDetails();
            mappedResponse.IpAddress = request.IpAddress;
            mappedResponse.Port = request.Port;
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

        private ServerStatusDetails BuildNullServerDetails()
        {
            return new ServerStatusDetails
            {
                Name = "Unknown",
                Players = new List<Player>(),
                AllDetails = new Dictionary<string, string>(),
                Ping = 9999
            };
        }
    }
}
