using GameBrowser.Api.Mappers;
using GameBrowser.Api.Models;
using GameBrowser.Enums;
using NUnit.Framework;

namespace GameBrowser.Api.Tests.Mappers
{
    public class ServerInfoRequestMapperTests
    {
        private ServerInfoRequest _input;
        private GameType _gameType;
        private GameBrowser.Models.ServerInfoRequest _result;

        [SetUp]
        public void SetUp()
        {
            _input = new ServerInfoRequest
            {
                IpAddress = "127.0.0.1",
                Port = 27960
            };
            _gameType = GameType.Quake3;

            var mapper = new ServerInfoRequestMapper();
            _result = mapper.Map(_input, _gameType);
        }

        [Test]
        public void CanMapIpAddress()
        {
            Assert.That(_result.IpAddress, Is.EqualTo(_input.IpAddress));
        }

        [Test]
        public void CanMapPort()
        {
            Assert.That(_result.Port, Is.EqualTo(_input.Port));
        }

        [Test]
        public void CanMapGameType()
        {
            Assert.That(_result.GameType, Is.EqualTo(_gameType));
        }
    }
}
