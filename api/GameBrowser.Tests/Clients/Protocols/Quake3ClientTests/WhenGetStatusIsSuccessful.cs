using GameBrowser.Clients;
using GameBrowser.Clients.Protocols;
using GameBrowser.Models;
using GameBrowser.Models.UdpServerClient;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Tests.Clients.Protocols.Quake3ClientTests
{
    public class WhenGetStatusIsSuccessful
    {
        private Quake3Client _protocolClient;
        private ServerResponse _expectedResponse;
        private ServerResponse _actualResponse;

        private Mock<IUdpServerClient> _udpServerClient;
        private Response _udpResponse;
        private byte[] _udpRequestPayload;
        private string _udpRequestPayloadString;

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

            _udpRequestPayload = new byte[] { 255, 255, 255, 255, 103, 101, 116, 115, 116, 97, 116, 117, 115 };
            _udpRequestPayloadString = System.Text.Encoding.Default.GetString(_udpRequestPayload);

            _expectedResponse = new ServerResponse
            {
                Data = "test info data",
                Error = null,
                Success = true
            };

            _udpServerClient = new Mock<IUdpServerClient>();
            _udpServerClient.Setup(c => c.GetData(It.Is<Request>(r => System.Text.Encoding.Default.GetString(r.Payload) == _udpRequestPayloadString))).ReturnsAsync(_udpResponse);

            _protocolClient = new Quake3Client(_udpServerClient.Object);
            _actualResponse = await _protocolClient.GetStatus(ipAddress, port);
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
        public void VerifyUdpServerClientGetDataIsCalledWithExpectedPayload()
        {
            _udpServerClient.Verify(u => u.GetData(It.Is<Request>(r => System.Text.Encoding.Default.GetString(r.Payload) == _udpRequestPayloadString)), Times.Once);
        }
    }
}
