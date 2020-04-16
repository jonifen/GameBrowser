using GameBrowser.Clients;
using GameBrowser.Mappers;
using GameBrowser.Models;
using GameBrowser.Models.Q3A;
using System.Collections.Generic;

namespace GameBrowser.Managers
{
    public class Q3AManager : IQ3AManager
    {
        private readonly IQ3AServerClient _q3aServerClient;
        private readonly IPingClient _pingClient;
        private readonly IQ3AServerResponseMapper _q3aServerResponseMapper;

        public Q3AManager(IQ3AServerClient q3aServerClient, IPingClient pingClient, IQ3AServerResponseMapper q3aServerResponseMapper)
        {
            _q3aServerClient = q3aServerClient;
            _pingClient = pingClient;
            _q3aServerResponseMapper = q3aServerResponseMapper;
        }

        public ServerDetails GetServerDetails(string ipAddress, int port)
        {
            var pingResponse = _pingClient.Ping(ipAddress);
            var serverResponse = pingResponse.Success ? _q3aServerClient.GetStatus(ipAddress, port) : BuildNullServerResponse();

            var mappedResponse = serverResponse.Success ? _q3aServerResponseMapper.Map(serverResponse.Data) : BuildNullServerDetails();
            mappedResponse.IpAddress = ipAddress;
            mappedResponse.Port = port;
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
