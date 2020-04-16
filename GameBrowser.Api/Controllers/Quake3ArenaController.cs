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
        [HttpPost]
        public async Task<ActionResult> GetServerInfo(ServerInfoRequest request)
        {
            var q3aManager = new Q3AManager();
            var serverDetails = q3aManager.GetServerDetails(request.IpAddress, request.Port);

            if (serverDetails.Status != ServerStatus.Offline)
                return Ok(serverDetails);
            else
                return NotFound();
        }
    }
}