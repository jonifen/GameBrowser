using GameBrowser.Models;
using System.Threading.Tasks;

namespace GameBrowser.Clients.Protocols
{
    public interface IQuake3Client
    {
        Task<ServerResponse> GetInfo(string ipAddress, int port);
        Task<ServerResponse> GetStatus(string ipAddress, int port);
    }
}