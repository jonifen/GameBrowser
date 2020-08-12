using GameBrowser.Mappers.Quake3;
using GameBrowser.Models.Quake3;
using NUnit.Framework;
using System.Collections.Generic;

namespace GameBrowser.Tests.Mappers
{
    [TestFixture]
    public class Q3AServerResponseMapperTests
    {
        private string _serverResponse;
        private List<Player> _expectedPlayers;
        private StatusResponseMapper _mapper;
        private ServerStatusDetails _result;

        // Example payloads
        // "????statusResponse\n\\capturelimit\\8\\g_maxGameClients\\0\\bot_minplayers\\5\\sv_floodProtect\\1\\sv_maxPing\\0\\sv_minPing\\0\\sv_dlRate\\100\\sv_maxRate\\0\\sv_minRate\\0\\sv_maxclients\\12\\sv_hostname\\Home Server\\g_gametype\\0\\timelimit\\15\\fraglimit\\20\\dmflags\\0\\version\\ioq3 1.36_GIT_f2c61c14-2020-02-11 linux-x86_64 Apr 11 2020\\com_gamename\\Quake3Arena\\com_protocol\\71\\mapname\\Q3DM8\\sv_privateClients\\0\\sv_allowDownload\\0\\gamename\\baseq3\\g_needpass\\0\n15 3 \"^5AbyssMisty\"\n13 0 \"Doom\"\n6 0 \"Angel\"\n10 4 \"^1cherry\"\n6 0 \"Phobos\"\n"
        // "????infoResponse\n\\voip\\opus\\g_needpass\\0\\pure\\1\\gametype\\0\\sv_maxclients\\12\\g_humanplayers\\2\\clients\\5\\mapname\\Q3DM8\\hostname\\Home Server\\protocol\\68\\gamename\\Quake3Arena"

        [SetUp]
        public void Setup()
        {
            _serverResponse = "????statusResponse\n\\capturelimit\\8\\g_maxGameClients\\0\\bot_minplayers\\5\\sv_floodProtect\\1\\sv_maxPing\\0\\sv_minPing\\0\\sv_dlRate\\100\\sv_maxRate\\0\\sv_minRate\\0\\sv_maxclients\\12\\sv_hostname\\Home Server\\g_gametype\\0\\timelimit\\15\\fraglimit\\20\\dmflags\\0\\version\\ioq3 1.36_GIT_f2c61c14-2020-02-11 linux-x86_64 Apr 11 2020\\com_gamename\\Quake3Arena\\com_protocol\\71\\mapname\\Q3DM8\\sv_privateClients\\0\\sv_allowDownload\\0\\gamename\\baseq3\\g_needpass\\0\n15 3 \"^5AbyssMisty\"\n13 0 \"Doom\"\n6 0 \"Angel\"\n10 4 \"^1cherry\"\n6 0 \"Phobos\"\n";
            _expectedPlayers = new List<Player>
            {
                new Player
                {
                    Name = "AbyssMisty",
                    Ping = 3,
                    Score = 15
                },
                new Player
                {
                    Name = "Doom",
                    Ping = 0,
                    Score = 13
                },
                new Player
                {
                    Name = "Angel",
                    Ping = 0,
                    Score = 6
                },
                new Player
                {
                    Name = "cherry",
                    Ping = 4,
                    Score = 10
                },
                new Player
                {
                    Name = "Phobos",
                    Ping = 0,
                    Score = 6
                }
            };

            _mapper = new StatusResponseMapper();

            _result = _mapper.Map(_serverResponse);
        }

        [Test]
        public void CanMapGameName()
        {
            Assert.AreEqual("baseq3", _result.GameName);
        }

        [Test]
        public void CanMapPlayerCount()
        {
            Assert.AreEqual(_expectedPlayers.Count, _result.Players.Count);
        }

        [Test]
        public void CanMapSecondPlayerName()
        {
            Assert.AreEqual("Doom", _result.Players[1].Name);
        }
    }
}
