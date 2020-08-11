namespace GameBrowser.Models.UnrealTournament99
{
    public class ServerRulesDetails
    {
        // Example payload
        // "\mutators\SmartCTF 4E, Rextended CTF v2-4, XC Enhanced spectator, Who Pushed Me?\listenserver\False\password\False\timelimit\15\goalteamscore\0\minplayers\0\changelevels\True\maxteams\2\balanceteams\True\playersbalanceteams\True\friendlyfire\0%\tournament\False\gamestyle\Hardcore\AdminName\SAM\AdminEMail\admin@testserver.com\queryid\66.1\final\"

        public string Mutators { get; set; }
        public bool ListenServer { get; set; }
        public bool Password { get; set; }
        public int TimeLimit { get; set; }
        public int GoalTeamScore { get; set; }
        public int MinPlayers { get; set; }
        public bool ChangeLevels { get; set; }
        public int MaxTeams { get; set; }
        public bool BalanceTeams { get; set; }
        public bool PlayersBalanceTeams { get; set; }
        public int FriendlyFire { get; set; }
        public bool Tournament { get; set; }
        public string GameStyle { get; set; }
        public string AdminName { get; set; }
        public string AdminEmail { get; set; }
        public string QueryId { get; set; }
    }
}
