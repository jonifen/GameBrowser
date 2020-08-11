using GameBrowser.Models;
using GameBrowser.Models.UnrealTournament99;
using System.Threading.Tasks;

namespace GameBrowser
{
    public interface IUT99Manager
    {
        Task<ServerInfoDetails> GetInfo(ServerInfoRequest request);
    }
}