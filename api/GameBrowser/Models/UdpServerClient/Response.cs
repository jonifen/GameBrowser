using System;
using System.Collections.Generic;
using System.Text;

namespace GameBrowser.Models.UdpServerClient
{
    public class Response
    {
        public bool Success { get; set; }
        public string Payload { get; set; }
        public string Error { get; set; }
    }
}
