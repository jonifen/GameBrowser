using GameBrowser.Clients;
using GameBrowser.Enums;
using GameBrowser.Managers;
using GameBrowser.Mappers.Quake3;
using GameBrowser.Models;
using GameBrowser.Tests.Helpers;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Tests.Managers
{
    [TestFixture]
    public class Q3AManagerTests
    {
        private ServerInfoRequest _request;

        [SetUp]
        public void SetUp()
        {
            _request = new ServerInfoRequest
            {
                IpAddress = "192.168.200.201",
                Port = 27960,
                GameType = GameType.Quake3
            };
        }

        [Test]
        public async Task ShouldReceiveValidServerResponse()
        {
            // Arrange
            var validPingResponse = PayloadBuilder.BuildValidPingResponse();
            var validServerResponse = PayloadBuilder.BuildValidServerResponse();
            var expectedResponse = PayloadBuilder.BuildMappedResponse();

            var mockPingClient = new Mock<IPingClient>();
            mockPingClient.Setup(ping => ping.Ping(_request.IpAddress)).Returns(Task.FromResult(validPingResponse));

            var mockServerClient = new Mock<IQ3AServerClient>();
            mockServerClient.Setup(server => server.GetStatus(_request.IpAddress, _request.Port)).Returns(validServerResponse);

            var mockServerResponseMapper = new Mock<IServerResponseMapper>();
            mockServerResponseMapper.Setup(map => map.Map(validServerResponse.Data)).Returns(expectedResponse);

            var manager = new Q3AManager(mockServerClient.Object, mockPingClient.Object, mockServerResponseMapper.Object);

            // Act
            var actualResponse = await manager.GetServerDetails(_request);

            // Assert
            Assert.AreEqual(actualResponse.Ping, validPingResponse.Milliseconds);
            Assert.AreEqual(actualResponse.IpAddress, _request.IpAddress);
            Assert.AreEqual(actualResponse.Name, expectedResponse.Name);
        }

        [Test]
        public async Task ShouldReceiveInvalidServerResponseDueToFailedPing()
        {
            // Arrange
            var invalidPingResponse = PayloadBuilder.BuildInvalidPingResponse();
            var invalidServerResponse = PayloadBuilder.BuildInvalidServerResponse();
            var expectedResponse = PayloadBuilder.BuildInvalidMappedResponse();

            var mockPingClient = new Mock<IPingClient>();
            mockPingClient.Setup(ping => ping.Ping(_request.IpAddress)).Returns(Task.FromResult(invalidPingResponse));

            var mockServerClient = new Mock<IQ3AServerClient>();
            mockServerClient.Setup(server => server.GetStatus(_request.IpAddress, _request.Port)).Returns(invalidServerResponse);

            var mockServerResponseMapper = new Mock<IServerResponseMapper>();
            mockServerResponseMapper.Setup(map => map.Map(invalidServerResponse.Data)).Returns(expectedResponse);

            var manager = new Q3AManager(mockServerClient.Object, mockPingClient.Object, mockServerResponseMapper.Object);

            // Act
            var actualResponse = await manager.GetServerDetails(_request);

            // Assert
            Assert.AreEqual(actualResponse.Ping, invalidPingResponse.Milliseconds);
            Assert.AreEqual(actualResponse.IpAddress, _request.IpAddress);
            Assert.AreEqual(actualResponse.Name, expectedResponse.Name);
        }
    }
}
