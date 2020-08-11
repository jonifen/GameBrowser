using GameBrowser.Models.UnrealTournament99;
using System;

namespace GameBrowser.Mappers.UnrealTournament99
{
    public class InfoResponseMapper : IInfoResponseMapper
    {
        public ServerInfoDetails Map(string payload)
        {
            if (string.IsNullOrWhiteSpace(payload))
                return BuildNullResponse();

            var data = payload.Substring(1).Split('\\');
            var info = new ServerInfoDetails();

            for (int index = 0; index < data.Length; index+=2)
            {
                switch (data[index])
                {
                    case "hostname":
                        info.HostName = data[index + 1];
                        break;
                    case "hostport":
                        info.HostPort = Convert.ToInt32(data[index + 1]);
                        break;
                    case "maptitle":
                        info.MapTitle = data[index + 1];
                        break;
                    case "mapname":
                        info.MapName = data[index + 1];
                        break;
                    case "gametype":
                        info.GameType = data[index + 1];
                        break;
                    case "numplayers":
                        info.PlayerCount = Convert.ToInt32(data[index + 1]);
                        break;
                    case "maxplayers":
                        info.MaxPlayers = Convert.ToInt32(data[index + 1]);
                        break;
                    case "gamemode":
                        info.GameMode = data[index + 1];
                        break;
                    case "gamever":
                        info.GameVersion = data[index + 1];
                        break;
                    case "minnetver":
                        info.MinNetVersion = data[index + 1];
                        break;
                    case "worldlog":
                        info.WorldLog = Convert.ToBoolean(data[index + 1]);
                        break;
                    case "wantworldlog":
                        info.WantWorldLog = Convert.ToBoolean(data[index + 1]);
                        break;
                    case "queryid":
                        info.QueryId = data[index + 1];
                        break;
                    default:
                        break;
                }
            }

            return info;
        }

        private ServerInfoDetails BuildNullResponse()
        {
            return new ServerInfoDetails
            {
                HostName = "Server not found"
            };
        }
    }
}
