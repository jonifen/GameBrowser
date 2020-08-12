using GameBrowser.Api.Controllers;
using GameBrowser.Api.Mappers;
using GameBrowser.Api.Models;
using GameBrowser.Enums;
using GameBrowser.Managers;
using GameBrowser.Models;
using GameBrowser.Models.Quake3;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Api.Tests.Controllers.Quake3ArenaControllerTests
{
    public class WhenTestingQuake3ArenaController
    {
        private ServerInfoRequest _controllerRequest;
        private ServerStatusDetails _expectedResponse;
        private Mock<IServerInfoRequestMapper> _mockServerInfoRequestMapper;
        private Mock<IQuake3Manager> _mockQuake3Manager;
        private string _actualResponse;

        [SetUp]
        public async Task SetUp()
        {
            _controllerRequest = new ServerInfoRequest
            {
                IpAddress = "192.168.201.201",
                Port = 27960
            };
            _expectedResponse = new ServerStatusDetails
            {
                Name = "test server name"
            };

            var gameType = GameType.Quake3;

            var managerRequest = new ServerRequest
            {
                IpAddress = _controllerRequest.IpAddress,
                Port = _controllerRequest.Port,
                GameType = gameType
            };

            _mockServerInfoRequestMapper = new Mock<IServerInfoRequestMapper>();
            _mockServerInfoRequestMapper.Setup(m => m.Map(_controllerRequest, gameType)).Returns(managerRequest);

            _mockQuake3Manager = new Mock<IQuake3Manager>();

            _mockQuake3Manager.Setup(x => x.GetStatus(managerRequest)).Returns(Task.FromResult(_expectedResponse));

            var controller = new Quake3ArenaController(_mockQuake3Manager.Object, _mockServerInfoRequestMapper.Object);

            var response = await controller.GetStatus(_controllerRequest);
            var content = response as OkObjectResult;
            _actualResponse = JsonConvert.SerializeObject(content.Value);
        }

        [Test]
        public void GetInfoShouldReturnExpectedResponse()
        {
            var expected = "{\"AllDetails\":null,\"GameName\":null,\"GameType\":null,\"IpAddress\":null,\"MapName\":null,\"MaxClients\":0,\"Name\":\"test server name\",\"Players\":null,\"Ping\":0,\"Port\":0,\"Status\":0}";
            Assert.That(_actualResponse, Is.EqualTo(expected));
        }
    }
}
