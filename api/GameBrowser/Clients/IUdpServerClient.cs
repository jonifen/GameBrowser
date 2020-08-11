using GameBrowser.Models;
using GameBrowser.Models.UdpServerClient;
using System.Threading.Tasks;

namespace GameBrowser.Clients
{
    public interface IUdpServerClient
    {
        Task<Response> GetData(Request request);
    }
}