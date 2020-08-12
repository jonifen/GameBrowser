using GameBrowser.Api.Controllers;
using GameBrowser.Api.Mappers;
using GameBrowser.Api.Models;
using GameBrowser.Enums;
using GameBrowser.Models;
using GameBrowser.Models.UnrealTournament99;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GameBrowser.Api.Tests.Controllers.UnrealTournament99ControllerTests
{
    public class WhenTestingUnrealTournament99Controller
    {
        private ServerInfoRequest _controllerRequest;
        private ServerInfoDetails _expectedResponse;
        private Mock<IServerInfoRequestMapper> _mockServerInfoRequestMapper;
        private Mock<IUnrealTournament99Manager> _mockUnrealTournament99Manager;
        private string _actualResponse;

        [SetUp]
        public async Task SetUp()
        {
            _controllerRequest = new ServerInfoRequest
            {
                IpAddress = "192.168.201.201",
                Port = 7778
            };
            _expectedResponse = new ServerInfoDetails
            {
                HostName = "test server name"
            };

            var gameType = GameType.UnrealTournament99;

            var managerRequest = new ServerRequest
            {
                IpAddress = _controllerRequest.IpAddress,
                Port = _controllerRequest.Port,
                GameType = gameType
            };

            _mockServerInfoRequestMapper = new Mock<IServerInfoRequestMapper>();
            _mockServerInfoRequestMapper.Setup(m => m.Map(_controllerRequest, gameType)).Returns(managerRequest);

            _mockUnrealTournament99Manager = new Mock<IUnrealTournament99Manager>();

            _mockUnrealTournament99Manager.Setup(x => x.GetInfo(managerRequest)).Returns(Task.FromResult(_expectedResponse));

            var controller = new UnrealTournament99Controller(_mockUnrealTournament99Manager.Object, _mockServerInfoRequestMapper.Object);

            var response = await controller.GetInfo(_controllerRequest);
            var content = response as OkObjectResult;
            _actualResponse = JsonConvert.SerializeObject(content.Value);
        }

        [Test]
        public void GetInfoShouldReturnExpectedResponse()
        {
            var expected = "{\"HostName\":\"test server name\",\"HostPort\":0,\"MapTitle\":null,\"MapName\":null,\"GameType\":null,\"PlayerCount\":0,\"MaxPlayers\":0,\"GameMode\":null,\"GameVersion\":null,\"MinNetVersion\":null,\"WorldLog\":false,\"WantWorldLog\":false,\"QueryId\":null,\"Ping\":0}";
            Assert.That(_actualResponse, Is.EqualTo(expected));
        }
    }
}
