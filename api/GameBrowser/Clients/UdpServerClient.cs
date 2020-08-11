using GameBrowser.Models.UdpServerClient;
using GameBrowser.Proxies;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameBrowser.Clients
{
    public class UdpServerClient : IUdpServerClient
    {
        private readonly ISocketProxy _socket;

        public UdpServerClient(ISocketProxy socket)
        {
            _socket = socket;
        }

        public async Task<Response> GetData(Request request)
        {
            var response = new Response
            {
                Success = true // Assume success unless proven otherwise
            };

            try
            {
                _socket.Connect(IPAddress.Parse(request.IpAddress), request.Port);

                var RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                _socket.Send(request.Payload, SocketFlags.None);

                // big enough to receive response
                var bufferRec = new Byte[64999];
                try
                {
                    _socket.Receive(bufferRec);
                }
                catch
                {
                    response.Success = false;
                }

                response.Payload = response.Success ? Encoding.ASCII.GetString(bufferRec) : string.Empty;

                _socket.Close();
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
