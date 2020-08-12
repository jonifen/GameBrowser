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
        private readonly IServerInfoRequestMapper _serverInfoRequestMapper;

        public Quake3ArenaController(IQuake3Manager q3aManager, IServerInfoRequestMapper serverInfoRequestMapper)
        {
            _q3aManager = q3aManager;
            _serverInfoRequestMapper = serverInfoRequestMapper;
        }

        [HttpGet]
        [Route("{IpAddress}/{Port}/status")]
        public async Task<ActionResult> GetStatus([FromRoute, ModelBinder] ApiModels.ServerInfoRequest request)
        {
            var serverRequest = _serverInfoRequestMapper.Map(request, GameType.Quake3);
            var serverDetails = await _q3aManager.GetStatus(serverRequest);

            if (serverDetails.Status != ServerStatus.Offline)
                return Ok(serverDetails);
            else
                return NotFound();
        }
    }
}