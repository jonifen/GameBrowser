using GameBrowser.Models.Quake3;

namespace GameBrowser.Mappers.Quake3
{
    public interface IServerResponseMapper
    {
        ServerDetails Map(string payload);
    }
}