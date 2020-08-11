using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using System;

namespace GameBrowser.Tests.Helpers
{
    public static class PayloadBuilder
    {
        public static PingResponse BuildValidPingResponse()
        {
            return new PingResponse
            {
                Milliseconds = 12,
                Success = true
            };
        }

        public static PingResponse BuildInvalidPingResponse()
        {
            return new PingResponse
            {
                Milliseconds = 9999,
                Success = false
            };
        }

        public static ServerInfoResponse BuildValidServerResponse()
        {
            return new ServerInfoResponse
            {
                Data = "????statusResponse\n\\capturelimit\\8\\g_maxGameClients\\0\\bot_minplayers\\5\\sv_floodProtect\\1\\sv_maxPing\\0\\sv_minPing\\0\\sv_dlRate\\100\\sv_maxRate\\0\\sv_minRate\\0\\sv_maxclients\\12\\sv_hostname\\Home Server\\g_gametype\\0\\timelimit\\15\\fraglimit\\20\\dmflags\\0\\version\\ioq3 1.36_GIT_f2c61c14-2020-02-11 linux-x86_64 Apr 11 2020\\com_gamename\\Quake3Arena\\com_protocol\\71\\mapname\\Q3DM8\\sv_privateClients\\0\\sv_allowDownload\\0\\gamename\\baseq3\\g_needpass\\0\n15 3 \"^5AbyssMisty\"\n13 0 \"Doom\"\n6 0 \"Angel\"\n10 4 \"^1cherry\"\n6 0 \"Phobos\"\n",
                Success = true
            };
        }

        public static ServerDetails BuildMappedResponse()
        {
            return new ServerDetails
            {
                Name = "Home Server"
            };
        }

        public static ServerDetails BuildInvalidMappedResponse()
        {
            return new ServerDetails
            {
                Name = "Unknown"
            };
        }

        public static ServerInfoResponse BuildInvalidServerResponse()
        {
            return new ServerInfoResponse
            {
                Error = "no bueno",
                Success = false
            };
        }
    }
}
