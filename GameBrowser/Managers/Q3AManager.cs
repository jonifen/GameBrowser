using GameBrowser.Clients;
using GameBrowser.Mappers;
using GameBrowser.Models;
using GameBrowser.Models.Q3A;
using System.Collections.Generic;

namespace GameBrowser.Managers
{
    public class Q3AManager
    {
        public ServerDetails GetServerDetails(string ipAddress, int port)
        {
            var server = new Q3AServerClient(ipAddress, port);
            var pingResponse = server.Ping();
            var serverResponse = pingResponse.Success ? server.GetInfo("getstatus") : BuildNullServerResponse();

            var mappedResponse = serverResponse.Success ? new Q3AServerResponseMapper().Map(serverResponse.Data) : BuildNullServerDetails();
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
                AllDetails = new Dictionary<string, string>()
            };
        }
    }
}
