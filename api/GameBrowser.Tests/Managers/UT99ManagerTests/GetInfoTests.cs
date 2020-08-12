using GameBrowser.Clients;
using GameBrowser.Clients.Games;
using GameBrowser.Enums;
using GameBrowser.Managers;
using GameBrowser.Mappers.UnrealTournament99;
using GameBrowser.Models;
using GameBrowser.Models.UnrealTournament99;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Tests.Managers.UT99ManagerTests
{
    public class GetInfoTests
    {
        private Mock<IPingClient> _mockPingClient;
        private Mock<IInfoResponseMapper> _mockInfoResponseMapper;
        private IUnrealTournament99Manager _manager;
        private ServerInfoDetails _result;
        private ServerRequest _serverRequest;
        private ServerResponse _serverResponse;
        private PingResponse _pingResponse;
        private Mock<IUnrealTournament99GameClient> _mockUnrealTournament99GameClient;

        [SetUp]
        public async Task SetUp()
        {
            _serverRequest = new ServerRequest
            {
                IpAddress = "192.168.200.201",
                Port = 7778,
                GameType = GameType.UnrealTournament99
            };

            _serverResponse = new ServerResponse
            {
                Data = @"\hostname\test server name\hostport\7777\maptitle\CTF-Bolt_HE (High End Systems)\mapname\CTF-Bolt_HE\gametype\ACLCTFGame\numplayers\11\maxplayers\13\gamemode\openplaying\gamever\451\minnetver\432\worldlog\false\wantworldlog\false\queryid\12.1\final\",
                Success = true,
                Error = string.Empty
            };

            _pingResponse = new PingResponse
            {
                Milliseconds = 50,
                Success = true
            };

            _mockUnrealTournament99GameClient = new Mock<IUnrealTournament99GameClient>();
            _mockPingClient = new Mock<IPingClient>();
            _mockInfoResponseMapper = new Mock<IInfoResponseMapper>();

            _mockPingClient.Setup(c => c.Ping(_serverRequest.IpAddress)).ReturnsAsync(_pingResponse);
            _mockUnrealTournament99GameClient.Setup(c => c.GetInfo(_serverRequest.IpAddress, _serverRequest.Port)).ReturnsAsync(_serverResponse);
            _mockInfoResponseMapper.Setup(c => c.Map(_serverResponse.Data)).Returns(new ServerInfoDetails { HostName = "test server name" });

            _manager = new UnrealTournament99Manager(_mockUnrealTournament99GameClient.Object, _mockPingClient.Object, _mockInfoResponseMapper.Object);

            _result = await _manager.GetInfo(_serverRequest);
        }

        [Test]
        public void CanCreateInstance()
        {
            Assert.That(_manager, Is.Not.Null);
        }

        [Test]
        public void ShouldReceiveResponseThatIsNotNull()
        {
            Assert.That(_result, Is.Not.Null);
        }

        [Test]
        public void ShouldCallPingClientMock()
        {
            _mockPingClient.Verify(c => c.Ping(_serverRequest.IpAddress), Times.Once);
        }

        [Test]
        public void ShouldCallGameClientMock()
        {
            _mockUnrealTournament99GameClient.Verify(c => c.GetInfo(_serverRequest.IpAddress, _serverRequest.Port), Times.Once);
        }

        [Test]
        public void ShouldCallInfoResponseMapperMock()
        {
            _mockInfoResponseMapper.Verify(c => c.Map(_serverResponse.Data), Times.Once);
        }

        [Test]
        public void ResultShouldContainExpectedHostName()
        {
            Assert.That(_result.HostName, Is.EqualTo("test server name"));
        }
    }
}
