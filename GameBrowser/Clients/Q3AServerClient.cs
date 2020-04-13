using GameBrowser.Models;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace GameBrowser.Clients
{
    public class Q3AServerClient
    {
        string _ipAddress = "";
        int _port = 0;

        public Q3AServerClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public PingResponse Ping()
        {
            var pingSvr = new Ping();
            var pingOpts = new PingOptions();

            // Use default TTL (=128), but change fragmentation behaviour
            pingOpts.DontFragment = true;

            // Create a buffer of 32 bytes to be transmitted.
            var buffer = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var timeout = 120;
            var reply = pingSvr.Send(_ipAddress, timeout, buffer, pingOpts);
            var pingSuccess = reply.Status == IPStatus.Success;

            return new PingResponse
            {
                Milliseconds = pingSuccess ? (int)reply.RoundtripTime : 9999,
                Success = pingSuccess
            };
        }

        public ServerInfoResponse GetInfo(string command)
        {
            // Make connection to game server, send data to server to request server info
            // Get server status: "ÿÿÿÿgetstatus"
            // Get server info:   "ÿÿÿÿgetinfo"
            var response = new ServerInfoResponse
            {
                Success = true // Assume success unless proven otherwise
            };

            try
            {
                using (var client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    client.Connect(IPAddress.Parse(_ipAddress), _port);

                    var bufferTemp = Encoding.ASCII.GetBytes(command);
                    var bufferSend = new Byte[bufferTemp.Length + 5];

                    // Build the first 4 characters (ÿÿÿÿ)
                    bufferSend[0] = Byte.Parse("255");
                    bufferSend[1] = Byte.Parse("255");
                    bufferSend[2] = Byte.Parse("255");
                    bufferSend[3] = Byte.Parse("255");

                    var bufferIndex = 4;

                    for (int i = 0; i < bufferTemp.Length; i++)
                    {
                        bufferSend[bufferIndex] = bufferTemp[i];
                        bufferIndex++;
                    }

                    var RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    client.Send(bufferSend, SocketFlags.None);

                    // big enough to receive response
                    var bufferRec = new Byte[64999];
                    try
                    {
                        client.Receive(bufferRec);
                    }
                    catch
                    {
                        response.Success = false;
                    }

                    response.Data = response.Success ? Encoding.ASCII.GetString(bufferRec).Replace("\0", "") : string.Empty;

                    client.Close();
                }
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
