using GameBrowser.Models;
using System.Net.NetworkInformation;
using System.Text;

namespace GameBrowser.Clients
{
    public class PingClient
    {
        public PingResponse Ping(string ipAddress)
        {
            var pingSvr = new Ping();
            var pingOpts = new PingOptions
            {
                DontFragment = true
            };

            // Create a buffer of 32 bytes to be transmitted.
            var buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var timeout = 120;
            var reply = pingSvr.Send(ipAddress, timeout, buffer, pingOpts);
            var pingSuccess = reply.Status == IPStatus.Success;

            return new PingResponse
            {
                Milliseconds = pingSuccess ? (int)reply.RoundtripTime : 9999,
                Success = pingSuccess
            };
        }
    }
}
