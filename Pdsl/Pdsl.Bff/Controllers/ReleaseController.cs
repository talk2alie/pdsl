using Microsoft.AspNetCore.Mvc;
using Pdsl.Bff.Models;
using Pdsl.Bff.Services;

namespace Pdsl.Bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleaseController : ControllerBase
    {
        private readonly ILogger<ReleaseController> logger;
        private readonly PdslService pdslService;

        public ReleaseController(ILogger<ReleaseController> logger, PdslService pdslService)
        {
            this.logger = logger;
            this.pdslService = pdslService;
        }

        [HttpGet("archived")]
        public async Task<IActionResult> GetArchivedReleases() => Ok(await pdslService.GetArchivedReleases());

        [HttpGet("most-recent")]
        public async Task<IActionResult> GetMostRecentReleases() => Ok(await pdslService.GetMostReleases());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReleaseById([FromRoute] string id)
        {
            var release = await pdslService.GetReleaseById(id);
            if(release is null)
            {
                return NotFound();
            }

            return Ok(release);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelease([FromBody] ReleaseInputViewModel releaseToAdd)
        {
            var release = await pdslService.AddRelease(releaseToAdd);
            if(release is null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            return Ok(release);
        }
    }
}