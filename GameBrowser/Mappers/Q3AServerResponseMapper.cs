using GameBrowser.Models.Q3A;
using System;
using System.Collections.Generic;

namespace GameBrowser.Mappers
{
    public class Q3AServerResponseMapper
    {
        // An example payload broken down by newline character (explains the magic numbers used).
        // [0] = "????statusResponse
        // [1] = "\\capturelimit\\8\\g_maxGameClients\\0\\bot_minplayers\\5\\sv_floodProtect\\1\\sv_maxPing\\0\\sv_minPing\\0\\sv_dlRate\\100\\sv_maxRate\\0\\sv_minRate\\0\\sv_maxclients\\12\\sv_hostname\\Home Server\\g_gametype\\0\\timelimit\\15\\fraglimit\\20\\dmflags\\0\\version\\ioq3 1.36_GIT_f2c61c14-2020-02-11 linux-x86_64 Apr 11 2020\\com_gamename\\Quake3Arena\\com_protocol\\71\\mapname\\Q3DM8\\sv_privateClients\\0\\sv_allowDownload\\0\\gamename\\baseq3\\g_needpass\\0"
        // [2] = "15 3 \"^5AbyssMisty\""
        // [3] = "13 0 \"Doom\""
        // [4] = "6 0 \"Angel\""
        // [5] = "10 4 \"^1cherry\""
        // [6] = "6 0 \"Phobos\""
        // [7] = ""

        public ServerDetails Map(string payload)
        {
            var data = payload.Split('\n');
            var details = MapServerDetails(data[1]);
            details.Players = MapPlayerInfo(data);

            return details;
        }

        private ServerDetails MapServerDetails(string payload)
        {
            var serverDetailsArray = payload.Split('\\');
            var info = new Dictionary<string, string>();

            // Start iterator at 1 to skip the empty first message
            for (var i = 1; i < serverDetailsArray.Length; i++)
            {
                if (i + 1 <= serverDetailsArray.Length)
                {
                    info.Add(serverDetailsArray[i].ToString(), serverDetailsArray[i + 1].ToString());
                    i++;
                }
            }

            return new ServerDetails
            {
                AllDetails = info,
                GameName = info["gamename"],
                GameType = info["g_gametype"],
                MapName = info["mapname"],
                MaxClients = Convert.ToInt32(info["sv_maxclients"]),
                Name = info["sv_hostname"]
            };
        }

        private IList<Player> MapPlayerInfo(string[] data)
        {
            var players = new List<Player>();
            var spaceChar = new char[] { (char)32 };

            // Start iterator at 2 to pull player data only
            for (var i = 2; i < data.Length; i++)
            {
                if ((data[i] != "") && (data[i] != "0"))
                {
                    var playerInfoArray = data[i].Split(spaceChar);

                    var playerName = string.Empty;
                    for (int p = 2; p < playerInfoArray.Length; p++)
                    {
                        playerName = playerName + " " + playerInfoArray[p].ToString();
                    }

                    playerName = playerName.Replace("\"", "");
                    playerName = playerName.Trim();
                    playerName = StripColourTags(playerName);

                    players.Add(new Player
                    {
                        Name = playerName,
                        Score = Convert.ToInt32(playerInfoArray[0]),
                        Ping = Convert.ToInt32(playerInfoArray[1])
                    });
                }
            }

            return players;
        }

        private string StripColourTags(string value)
        {
            var output = string.Empty;

            var stringEnum = value.GetEnumerator();

            while (stringEnum.MoveNext())
            {
                var caretFound = stringEnum.Current.ToString() == "^";
                if (!caretFound)
                    output = output + stringEnum.Current.ToString();
            }

            return output;
        }
    }
}
