using GameBrowser.Enums;
using ApiModels = GameBrowser.Api.Models;
using DomainModels = GameBrowser.Models;

namespace GameBrowser.Api.Mappers
{
    public class ServerInfoRequestMapper
    {
        public DomainModels.ServerInfoRequest Map(ApiModels.ServerInfoRequest request, GameType gameType)
        {
            return new DomainModels.ServerInfoRequest
            {
                IpAddress = request.IpAddress,
                Port = request.Port,
                GameType = gameType
            };
        }
    }
}
