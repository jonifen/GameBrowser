using GameBrowser.Enums;
using System.Collections.Generic;

namespace GameBrowser.Models.Quake3
{
    public class ServerStatusDetails
    {
        public Dictionary<string, string> AllDetails { get; set; }
        public string GameName { get; set; }
        public string GameType { get; set; }
        public string IpAddress { get; set; }
        public string MapName { get; set; }
        public int MaxClients { get; set; }
        public string Name { get; set; }
        public IList<Player> Players { get; set; }
        public int Ping { get; set; }
        public int Port { get; set; }
        public ServerStatus Status { get; set; }
    }
}
