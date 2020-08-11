using GameBrowser.Models.UnrealTournament99;

namespace GameBrowser.Mappers.UnrealTournament99
{
    public interface IInfoResponseMapper
    {
        ServerInfoDetails Map(string payload);
    }
}