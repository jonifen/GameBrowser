using GameBrowser.Api.Models;
using GameBrowser.Enums;
using GameBrowser.Models;

namespace GameBrowser.Api.Mappers
{
    public interface IServerInfoRequestMapper
    {
        ServerRequest Map(ServerInfoRequest request, GameType gameType);
    }
}