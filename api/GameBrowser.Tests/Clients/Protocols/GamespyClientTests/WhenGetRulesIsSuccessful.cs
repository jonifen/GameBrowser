using GameBrowser.Clients;
using GameBrowser.Clients.Protocols;
using GameBrowser.Models;
using GameBrowser.Models.UdpServerClient;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Tests.Clients.Protocols.GamespyClientTests
{
    public class WhenGetRulesIsSuccessful
    {
        private GamespyClient _protocolClient;
        private ServerResponse _expectedResponse;
        private ServerResponse _actualResponse;

        private Mock<IUdpServerClient> _udpServerClient;
        private Response _udpResponse;

        [SetUp]
        public async Task SetUp()
        {
            var ipAddress = "192.168.201.201";
            var port = 7778;

            _udpResponse = new Response
            {
                Payload = "test info data",
                Success = true,
                Error = null
            };

            _expectedResponse = new ServerResponse
            {
                Data = "test info data",
                Error = null,
                Success = true
            };

            _udpServerClient = new Mock<IUdpServerClient>();
            _udpServerClient.Setup(c => c.GetData(It.IsAny<Request>())).ReturnsAsync(_udpResponse);

            _protocolClient = new GamespyClient(_udpServerClient.Object);
            _actualResponse = await _protocolClient.GetRules(ipAddress, port);
        }

        [Test]
        public void ShouldReturnData()
        {
            Assert.That(_actualResponse.Data, Is.EqualTo(_expectedResponse.Data));
        }

        [Test]
        public void ShouldReturnNullError()
        {
            Assert.That(_actualResponse.Error, Is.Null);
        }

        [Test]
        public void ShouldReturnSuccessTrue()
        {
            Assert.That(_actualResponse.Success, Is.True);
        }

        [Test]
        public void VerifyUdpServerClientGetDataIsCalled()
        {
            _udpServerClient.Verify(u => u.GetData(It.IsAny<Request>()), Times.Once);
        }
    }
}
