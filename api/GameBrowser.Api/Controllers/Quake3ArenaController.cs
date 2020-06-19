using GameBrowser.Api.Models;
using GameBrowser.Managers;
using GameBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetServerInformation([FromRoute, ModelBinder] ServerInfoRequest request)
        {
            var serverDetails = _q3aManager.GetServerDetails(request.IpAddress, request.Port);

            if (serverDetails.Status != ServerStatus.Offline)
                return Ok(serverDetails);
            else
                return NotFound();
        }
    }
}