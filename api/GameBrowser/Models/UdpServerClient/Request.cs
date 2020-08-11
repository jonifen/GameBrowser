using System;

namespace GameBrowser.Models.UdpServerClient
{
    public class Request
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public byte[] Payload { get; set; }
    }
}
