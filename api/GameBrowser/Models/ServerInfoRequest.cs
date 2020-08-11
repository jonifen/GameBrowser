using GameBrowser.Enums;

namespace GameBrowser.Models
{
    public class ServerInfoRequest
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public GameType GameType { get; set; }
    }
}
