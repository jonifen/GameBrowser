using GameBrowser.Clients;
using GameBrowser.Clients.Protocols;
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
        private Mock<IGamespyClient> _mockGamespyClient;
        private Mock<IPingClient> _mockPingClient;
        private Mock<IInfoResponseMapper> _mockInfoResponseMapper;
        private IUT99Manager _manager;
        private ServerInfoDetails _result;
        private ServerInfoRequest _serverRequest;
        private ServerInfoResponse _serverResponse;
        private PingResponse _pingResponse;

        [SetUp]
        public async Task SetUp()
        {
            _serverRequest = new ServerInfoRequest
            {
                //IpAddress = "192.168.200.201",
                IpAddress = "185.107.96.18", // TODO - comment this out before commit
                Port = 7778, // Port 7777 for game, 7778 for server query
                GameType = GameType.UnrealTournament99
            };

            _serverResponse = new ServerInfoResponse
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

            _mockGamespyClient = new Mock<IGamespyClient>();
            _mockPingClient = new Mock<IPingClient>();
            _mockInfoResponseMapper = new Mock<IInfoResponseMapper>();

            _mockPingClient.Setup(c => c.Ping(_serverRequest.IpAddress)).ReturnsAsync(_pingResponse);
            _mockGamespyClient.Setup(c => c.GetInfo(_serverRequest.IpAddress, _serverRequest.Port)).ReturnsAsync(_serverResponse);
            _mockInfoResponseMapper.Setup(c => c.Map(_serverResponse.Data)).Returns(new ServerInfoDetails { HostName = "test server name" });

            _manager = new UT99Manager(_mockGamespyClient.Object, _mockPingClient.Object, _mockInfoResponseMapper.Object);
            //_manager = new UT99Manager(
            //    new GamespyClient(
            //        new UdpServerClient(
            //            new SocketProxy(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            //        )
            //    ),
            //    new PingClient(),
            //    new InfoResponseMapper());

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
        public void ShouldCallGamespyClientMock()
        {
            _mockGamespyClient.Verify(c => c.GetInfo(_serverRequest.IpAddress, _serverRequest.Port), Times.Once);
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
