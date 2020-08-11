namespace GameBrowser.Models.UnrealTournament99
{
    public class ServerStatusDetails
    {
        // Example payload
        // "\gamename\ut\gamever\451\minnetver\432\location\0\hostname\test server name\hostport\7777\maptitle\CTF-Bolt_HE (High End Systems)\mapname\CTF-Bolt_HE\gametype\ACLCTFGame\numplayers\11\maxplayers\13\gamemode\openplaying\gamever\451\minnetver\432\worldlog\false\wantworldlog\false\mutators\SmartCTF 4E, Rextended CTF v2-4, XC Enhanced spectator, Who Pushed Me?\listenserver\False\password\False\timelimit\15\goalteamscore\0\minplayers\0\changelevels\True\maxteams\2\balanceteams\True\playersbalanceteams\True\friendlyfire\0%\tournament\False\gamestyle\Hardcore\AdminName\SAM\AdminEMail\admin@testserver.com\player_0\fred\frags_0\0\ping_0\ 61\team_0\255\mesh_0\Spectator\skin_0\None\face_0\\ngsecret_0\true\player_1\steve\frags_1\401\ping_1\ 127\team_1\1\mesh_1\Male Soldier\skin_1\SoldierSkins.hkil\face_1\SoldierSkins.matrix\ngsecret_1\true\queryid\60.1"

        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public string MinNetVersion { get; set; }
        public string Location { get; set; }
        public string HostName { get; set; }
        public int HostPort { get; set; }
        public string MapTitle { get; set; }
        public string MapName { get; set; }
        public string GameType { get; set; }
        public int PlayerCount { get; set; }
        public int MaxPlayers { get; set; }
        public string GameMode { get; set; }
        public bool WorldLog { get; set; }
        public bool WantWorldLog { get; set; }
        public string Mutators { get; set; }
        public bool ListenServer { get; set; }
        public bool Password { get; set; }
        public int TimeLimit { get; set; }
        public int GoalTeamScore { get; set; }
        public int MinPlayers { get; set; }
        public int ChangeLevels { get; set; }
        public int MaxTeams { get; set; }
        public bool BalanceTeams { get; set; }
        public bool PlayersBalanceTeams { get; set; }
        public bool FriendlyFire { get; set; }
        public bool Tournament { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public Player[] Players { get; set; }
        public string QueryId { get; set; }
    }
}
