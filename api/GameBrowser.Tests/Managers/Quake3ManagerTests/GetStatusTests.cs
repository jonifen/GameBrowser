using GameBrowser.Clients;
using GameBrowser.Clients.Games;
using GameBrowser.Enums;
using GameBrowser.Managers;
using GameBrowser.Mappers.Quake3;
using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Tests.Managers.Quake3ManagerTests
{
    public class GetStatusTests
    {
        private Mock<IPingClient> _mockPingClient;
        private Mock<IStatusResponseMapper> _mockStatusResponseMapper;
        private IQuake3Manager _manager;
        private ServerStatusDetails _result;
        private ServerRequest _serverRequest;
        private ServerResponse _serverResponse;
        private PingResponse _pingResponse;
        private Mock<IQuake3GameClient> _mockQuake3GameClient;

        [SetUp]
        public async Task SetUp()
        {
            _serverRequest = new ServerRequest
            {
                IpAddress = "192.168.200.201",
                Port = 27960,
                GameType = GameType.Quake3
            };

            _serverResponse = new ServerResponse
            {
                Data = "????statusResponse\n\\capturelimit\\8\\g_maxGameClients\\0\\bot_minplayers\\5\\sv_floodProtect\\1\\sv_maxPing\\0\\sv_minPing\\0\\sv_dlRate\\100\\sv_maxRate\\0\\sv_minRate\\0\\sv_maxclients\\12\\sv_hostname\\test server name\\g_gametype\\0\\timelimit\\15\\fraglimit\\20\\dmflags\\0\\version\\ioq3 1.36_GIT_f2c61c14-2020-02-11 linux-x86_64 Apr 11 2020\\com_gamename\\Quake3Arena\\com_protocol\\71\\mapname\\Q3DM8\\sv_privateClients\\0\\sv_allowDownload\\0\\gamename\\baseq3\\g_needpass\\0\n15 3 \" ^ 5AbyssMisty\"\n13 0 \"Doom\"\n6 0 \"Angel\"\n10 4 \"^1cherry\"\n6 0 \"Phobos\"\n",
                Success = true,
                Error = string.Empty
            };

            _pingResponse = new PingResponse
            {
                Milliseconds = 50,
                Success = true
            };

            _mockQuake3GameClient = new Mock<IQuake3GameClient>();
            _mockPingClient = new Mock<IPingClient>();
            _mockStatusResponseMapper = new Mock<IStatusResponseMapper>();

            _mockPingClient.Setup(c => c.Ping(_serverRequest.IpAddress)).ReturnsAsync(_pingResponse);
            _mockQuake3GameClient.Setup(c => c.GetStatus(_serverRequest.IpAddress, _serverRequest.Port)).ReturnsAsync(_serverResponse);
            _mockStatusResponseMapper.Setup(c => c.Map(_serverResponse.Data)).Returns(new ServerStatusDetails { Name = "test server name" });

            _manager = new Quake3Manager(_mockQuake3GameClient.Object, _mockPingClient.Object, _mockStatusResponseMapper.Object);

            _result = await _manager.GetStatus(_serverRequest);
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
            _mockQuake3GameClient.Verify(c => c.GetStatus(_serverRequest.IpAddress, _serverRequest.Port), Times.Once);
        }

        [Test]
        public void ShouldCallInfoResponseMapperMock()
        {
            _mockStatusResponseMapper.Verify(c => c.Map(_serverResponse.Data), Times.Once);
        }

        [Test]
        public void ResultShouldContainExpectedHostName()
        {
            Assert.That(_result.Name, Is.EqualTo("test server name"));
        }
    }
}
