using GameBrowser.Models;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GameBrowser.Clients
{
    public class PingClient : IPingClient
    {
        public async Task<PingResponse> Ping(string ipAddress)
        {
            var pingSvr = new Ping();
            var pingOpts = new PingOptions
            {
                DontFragment = true
            };

            // Create a buffer of 32 bytes to be transmitted.
            var buffer = Encoding.ASCII.GetBytes(new string('a', 32));
            var timeout = 120;
            var reply = await pingSvr.SendPingAsync(ipAddress, timeout, buffer, pingOpts);
            var pingSuccess = reply.Status == IPStatus.Success;

            return new PingResponse
            {
                Milliseconds = pingSuccess ? (int)reply.RoundtripTime : 9999,
                Success = pingSuccess
            };
        }
    }
}
