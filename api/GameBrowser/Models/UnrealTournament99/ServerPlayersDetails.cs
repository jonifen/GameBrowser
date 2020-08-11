namespace GameBrowser.Models.UnrealTournament99
{
    public class ServerPlayersDetails
    {
        // Example payload
        // "\player_0\elizabeth\frags_0\0\ping_0\ 39\team_0\0\mesh_0\Boss\skin_0\BossSkins.boss\face_0\BossSkins.T_0\ngsecret_0\true\player_1\fred\frags_1\0\ping_1\ 61\team_1\255\mesh_1\Spectator\skin_1\None\face_1\\ngsecret_1\true\player_2\steve\frags_2\447\ping_2\ 128\team_2\1\mesh_2\Male Soldier\skin_2\SoldierSkins.hkil\face_2\SoldierSkins.matrix\ngsecret_2\true\player_3\alison\frags_3\203\ping_3\ 66\team_3\255\mesh_3\Spectator\skin_3\None\face_3\\ngsecret_3\true\player_4\gary\frags_4\738\ping_4\ 38\team_4\0\mesh_4\Male Soldier\skin_4\SoldierSkins.Blkt\face_4\SoldierSkins.Malcom\ngsecret_4\true\player_5\beryl\frags_5\500\ping_5\ 167\team_5\1\mesh_5\Female Soldier\skin_5\SGirlSkins.fbth\face_5\SGirlSkins.Annaka\ngsecret_5\true\player_6\bob\frags_6\477\ping_6\ 279\team_6\1\mesh_6\Boss\skin_6\BossSkins.boss\face_6\BossSkins.T_1\ngsecret_6\true\queryid\69.1"

        public Player[] Players { get; set; }
        public string QueryId { get; set; }
    }
}
