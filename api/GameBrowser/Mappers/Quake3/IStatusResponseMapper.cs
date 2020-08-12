using GameBrowser.Models.Quake3;

namespace GameBrowser.Mappers.Quake3
{
    public interface IStatusResponseMapper
    {
        ServerStatusDetails Map(string payload);
    }
}