using GameBrowser.Enums;
using ApiModels = GameBrowser.Api.Models;
using DomainModels = GameBrowser.Models;

namespace GameBrowser.Api.Mappers
{
    public class ServerInfoRequestMapper : IServerInfoRequestMapper
    {
        public DomainModels.ServerRequest Map(ApiModels.ServerInfoRequest request, GameType gameType)
        {
            return new DomainModels.ServerRequest
            {
                IpAddress = request.IpAddress,
                Port = request.Port,
                GameType = gameType
            };
        }
    }
}
