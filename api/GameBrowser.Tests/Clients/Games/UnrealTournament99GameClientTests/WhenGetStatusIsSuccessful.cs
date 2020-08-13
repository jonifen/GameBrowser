using GameBrowser.Clients.Games;
using GameBrowser.Clients.Protocols;
using GameBrowser.Models;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Tests.Clients.Games.UnrealTournament99GameClientTests
{
    public class WhenGetStatusIsSuccessful
    {
        private Mock<IGamespyClient> _protocolClient;
        private string _ipAddress;
        private int _port;
        private ServerResponse _expectedResponse;
        private UnrealTournament99GameClient _gameClient;
        private ServerResponse _response;

        [SetUp]
        public async Task SetUp()
        {
            _ipAddress = "192.168.201.201";
            _port = 27960;
            _expectedResponse = new ServerResponse
            {
                Data = "test status data",
                Error = null,
                Success = true
            };

            _protocolClient = new Mock<IGamespyClient>();
            _protocolClient.Setup(c => c.GetStatus(_ipAddress, _port)).ReturnsAsync(_expectedResponse);

            _gameClient = new UnrealTournament99GameClient(_protocolClient.Object);
            _response = await _gameClient.GetStatus(_ipAddress, _port);
        }

        [Test]
        public void ShouldReturnData()
        {
            Assert.That(_response.Data, Is.EqualTo(_expectedResponse.Data));
        }

        [Test]
        public void ShouldReturnNullError()
        {
            Assert.That(_response.Error, Is.Null);
        }

        [Test]
        public void ShouldReturnSuccessTrue()
        {
            Assert.That(_response.Success, Is.True);
        }
    }
}
