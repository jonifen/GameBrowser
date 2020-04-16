using GameBrowser.Models.Q3A;

namespace GameBrowser.Mappers
{
    public interface IQ3AServerResponseMapper
    {
        ServerDetails Map(string payload);
    }
}