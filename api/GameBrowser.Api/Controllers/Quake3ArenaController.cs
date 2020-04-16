using GameBrowser.Managers;
using GameBrowser.Models;
using GameBrowser.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameBrowser.Web.Controllers
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

        // It feels a bit sweaty to have a POST endpoint for getting server info,
        // but Swagger won't allow a GET endpoint to receive a body payload.
        [HttpPost]
        public async Task<ActionResult> GetServerInfo(ServerInfoRequest request)
        {
            var serverDetails = _q3aManager.GetServerDetails(request.IpAddress, request.Port);

            if (serverDetails.Status != ServerStatus.Offline)
                return Ok(serverDetails);
            else
                return NotFound();
        }
    }
}