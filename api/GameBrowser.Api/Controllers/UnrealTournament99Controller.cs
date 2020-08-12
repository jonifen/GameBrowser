using GameBrowser.Api.Mappers;
using GameBrowser.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiModels = GameBrowser.Api.Models;

namespace GameBrowser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnrealTournament99Controller : ControllerBase
    {
        private readonly IUnrealTournament99Manager _manager;
        private readonly IServerInfoRequestMapper _serverInfoRequestMapper;

        public UnrealTournament99Controller(IUnrealTournament99Manager manager, IServerInfoRequestMapper serverInfoRequestMapper)
        {
            _manager = manager;
            _serverInfoRequestMapper = serverInfoRequestMapper;
        }

        [HttpGet]
        [Route("{IpAddress}/{Port}/info")]
        public async Task<IActionResult> GetInfo([FromRoute, ModelBinder] ApiModels.ServerInfoRequest request)
        {
            var serverRequest = _serverInfoRequestMapper.Map(request, GameType.UnrealTournament99);
            var serverDetails = await _manager.GetInfo(serverRequest);

            if (serverDetails.Ping == 9999)
                return NotFound();

            return Ok(serverDetails);
        }
    }
}
