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
        private readonly IUT99Manager _manager;

        public UnrealTournament99Controller(IUT99Manager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("{IpAddress}/{Port}")]
        public async Task<IActionResult> GetInfo([FromRoute, ModelBinder] ApiModels.ServerInfoRequest request)
        {
            var serverRequest = new ServerInfoRequestMapper().Map(request, GameType.UnrealTournament99);
            var serverDetails = await _manager.GetInfo(serverRequest);

            if (serverDetails.Ping == 9999)
                return NotFound();

            return Ok(serverDetails);
        }
    }
}
