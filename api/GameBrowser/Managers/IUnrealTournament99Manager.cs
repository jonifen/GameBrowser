using GameBrowser.Models;
using GameBrowser.Models.UnrealTournament99;
using System.Threading.Tasks;

namespace GameBrowser
{
    public interface IUnrealTournament99Manager
    {
        Task<ServerInfoDetails> GetInfo(ServerRequest request);
    }
}