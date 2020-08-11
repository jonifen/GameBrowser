namespace GameBrowser.Models.UnrealTournament99
{
    public class ServerInfoDetails
    {
        // Example payload
        // "\hostname\test server name\hostport\7777\maptitle\CTF-Bolt_HE (High End Systems)\mapname\CTF-Bolt_HE\gametype\ACLCTFGame\numplayers\11\maxplayers\13\gamemode\openplaying\gamever\451\minnetver\432\worldlog\false\wantworldlog\false\queryid\12.1\final\"

        public string HostName { get; set; }
        public int HostPort { get; set; }
        public string MapTitle { get; set; }
        public string MapName { get; set; }
        public string GameType { get; set; }
        public int PlayerCount { get; set; }
        public int MaxPlayers { get; set; }
        public string GameMode { get; set; }
        public string GameVersion { get; set; }
        public string MinNetVersion { get; set; }
        public bool WorldLog { get; set; }
        public bool WantWorldLog { get; set; }
        public string QueryId { get; set; }
        public int Ping { get; set; }
    }
}
