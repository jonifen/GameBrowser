using GameBrowser.Proxies;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GameBrowser.Tests.Helpers
{
    public class TestServer
    {
        private readonly ISocketProxy _server;

        public TestServer()
        {
            _server = new SocketProxy(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }

        public void Run()
        {
            var hostIp = (Dns.GetHostEntry(IPAddress.Any.ToString())).AddressList[0];
            var endpoint = new IPEndPoint(hostIp, 49389);
            _server.Bind(endpoint);
            _server.Listen(100);
        }
    }
}
