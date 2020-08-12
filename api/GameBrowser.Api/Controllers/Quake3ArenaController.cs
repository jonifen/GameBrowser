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
        private readonly IQuake3Manager _q3aManager;

        public Quake3ArenaController(IQuake3Manager q3aManager)
        {
            _q3aManager = q3aManager;
        }

        [HttpGet]
        [Route("{IpAddress}/{Port}")]
        public async Task<ActionResult> GetServerInformation([FromRoute, ModelBinder] ApiModels.ServerInfoRequest request)
        {
            var serverRequest = new ServerInfoRequestMapper().Map(request, GameType.Quake3);
            var serverDetails = await _q3aManager.GetStatus(serverRequest);

            if (serverDetails.Status != ServerStatus.Offline)
                return Ok(serverDetails);
            else
                return NotFound();
        }
    }
}