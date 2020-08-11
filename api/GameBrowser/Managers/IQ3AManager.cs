using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using System.Threading.Tasks;

namespace GameBrowser.Managers
{
    public interface IQ3AManager
    {
        Task<ServerDetails> GetServerDetails(ServerInfoRequest request);
    }
}