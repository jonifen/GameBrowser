using GameBrowser.Clients;
using GameBrowser.Managers;
using GameBrowser.Mappers;
using GameBrowser.Models;
using GameBrowser.Models.Q3A;
using GameBrowser.Tests.Helpers;
using Moq;
using NUnit.Framework;

namespace GameBrowser.Tests.Managers
{
    [TestFixture]
    public class Q3AManagerTests
    {
        const string _ipAddress = "192.168.200.201";
        const int _port = 27960;

        [Test]
        public void ShouldReceiveValidServerResponse()
        {
            // Arrange
            var validPingResponse = PayloadBuilder.BuildValidPingResponse();
            var validServerResponse = PayloadBuilder.BuildValidServerResponse();
            var expectedResponse = PayloadBuilder.BuildMappedResponse();

            var mockPingClient = new Mock<IPingClient>();
            mockPingClient.Setup(ping => ping.Ping(_ipAddress)).Returns(validPingResponse);

            var mockServerClient = new Mock<IQ3AServerClient>();
            mockServerClient.Setup(server => server.GetStatus(_ipAddress, _port)).Returns(validServerResponse);

            var mockServerResponseMapper = new Mock<IQ3AServerResponseMapper>();
            mockServerResponseMapper.Setup(map => map.Map(validServerResponse.Data)).Returns(expectedResponse);

            var manager = new Q3AManager(mockServerClient.Object, mockPingClient.Object, mockServerResponseMapper.Object);

            // Act
            var actualResponse = manager.GetServerDetails(_ipAddress, _port);

            // Assert
            Assert.AreEqual(actualResponse.Ping, validPingResponse.Milliseconds);
            Assert.AreEqual(actualResponse.IpAddress, _ipAddress);
            Assert.AreEqual(actualResponse.Name, expectedResponse.Name);
        }

        [Test]
        public void ShouldReceiveInvalidServerResponseDueToFailedPing()
        {
            // Arrange
            var invalidPingResponse = PayloadBuilder.BuildInvalidPingResponse();
            var invalidServerResponse = PayloadBuilder.BuildInvalidServerResponse();
            var expectedResponse = PayloadBuilder.BuildInvalidMappedResponse();

            var mockPingClient = new Mock<IPingClient>();
            mockPingClient.Setup(ping => ping.Ping(_ipAddress)).Returns(invalidPingResponse);

            var mockServerClient = new Mock<IQ3AServerClient>();
            mockServerClient.Setup(server => server.GetStatus(_ipAddress, _port)).Returns(invalidServerResponse);

            var mockServerResponseMapper = new Mock<IQ3AServerResponseMapper>();
            mockServerResponseMapper.Setup(map => map.Map(invalidServerResponse.Data)).Returns(expectedResponse);

            var manager = new Q3AManager(mockServerClient.Object, mockPingClient.Object, mockServerResponseMapper.Object);

            // Act
            var actualResponse = manager.GetServerDetails(_ipAddress, _port);

            // Assert
            Assert.AreEqual(actualResponse.Ping, invalidPingResponse.Milliseconds);
            Assert.AreEqual(actualResponse.IpAddress, _ipAddress);
            Assert.AreEqual(actualResponse.Name, expectedResponse.Name);
        }
    }
}
