using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using System.Threading.Tasks;

namespace GameBrowser.Managers
{
    public interface IQuake3Manager
    {
        Task<ServerStatusDetails> GetStatus(ServerRequest request);
    }
}