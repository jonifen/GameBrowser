using GameBrowser.Api.Mappers;
using GameBrowser.Enums;
using GameBrowser.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApiModels = GameBrowser.Api.Models;

namespace GameBrowser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Quake3ArenaController : ControllerBase
    {
        private readonly IQ3AManager _q3aManager;

        public Quake3ArenaController(IQ3AManager q3aManager)
        {
            _q3aManager = q3aManager;
        }

        [HttpGet]
        [Route("{IpAddress}/{Port}")]
        public async Task<ActionResult> GetServerInformation([FromRoute, ModelBinder] ApiModels.ServerInfoRequest request)
        {
            var serverRequest = new ServerInfoRequestMapper().Map(request, GameType.Quake3);
            var serverDetails = await _q3aManager.GetServerDetails(serverRequest);

            if (serverDetails.Status != ServerStatus.Offline)
                return Ok(serverDetails);
            else
                return NotFound();
        }
    }
}