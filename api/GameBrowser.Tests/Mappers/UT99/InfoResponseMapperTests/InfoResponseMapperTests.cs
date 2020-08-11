using GameBrowser.Mappers.UnrealTournament99;
using GameBrowser.Models.UnrealTournament99;
using NUnit.Framework;

namespace GameBrowser.Tests.Mappers.UT99.InfoResponseMapperTests
{
    public class ValidPayloadMap
    {
        private ServerInfoDetails _result;

        [SetUp]
        public void SetUp()
        {
            var payload = @"\hostname\test server name\hostport\7777\maptitle\CTF-Bolt_HE (High End Systems)\mapname\CTF-Bolt_HE\gametype\ACLCTFGame\numplayers\11\maxplayers\13\gamemode\openplaying\gamever\451\minnetver\432\worldlog\false\wantworldlog\false\queryid\12.1\final\";
            _result = new InfoResponseMapper().Map(payload);
        }

        [Test]
        public void ShouldMapHostName()
        {
            Assert.That(_result.HostName, Is.EqualTo("test server name"));
        }

        [Test]
        public void ShouldMapHostPort()
        {
            Assert.That(_result.HostPort, Is.EqualTo(7777));
        }

        [Test]
        public void ShouldMapMapTitle()
        {
            Assert.That(_result.MapTitle, Is.EqualTo("CTF-Bolt_HE (High End Systems)"));
        }

        [Test]
        public void ShouldMapMapName()
        {
            Assert.That(_result.MapName, Is.EqualTo("CTF-Bolt_HE"));
        }

        [Test]
        public void ShouldMapGameType()
        {
            Assert.That(_result.GameType, Is.EqualTo("ACLCTFGame"));
        }

        [Test]
        public void ShouldMapPlayerCount()
        {
            Assert.That(_result.PlayerCount, Is.EqualTo(11));
        }

        [Test]
        public void ShouldMapMaxPlayers()
        {
            Assert.That(_result.MaxPlayers, Is.EqualTo(13));
        }

        [Test]
        public void ShouldMapGameMode()
        {
            Assert.That(_result.GameMode, Is.EqualTo("openplaying"));
        }

        [Test]
        public void ShouldMapGameVersion()
        {
            Assert.That(_result.GameVersion, Is.EqualTo("451"));
        }

        [Test]
        public void ShouldMapMinNetVersion()
        {
            Assert.That(_result.MinNetVersion, Is.EqualTo("432"));
        }

        [Test]
        public void ShouldMapWorldLog()
        {
            Assert.That(_result.WorldLog, Is.False);
        }

        [Test]
        public void ShouldMapWantWorldLog()
        {
            Assert.That(_result.WantWorldLog, Is.False);
        }

        [Test]
        public void ShouldMapQueryId()
        {
            Assert.That(_result.QueryId, Is.EqualTo("12.1"));
        }
    }
}
