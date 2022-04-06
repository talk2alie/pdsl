using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Models;
using Pdsl.Api.Services;
using Pdsl.Api.ViewModels;

namespace Pdsl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleaseController : AppController
    {
        public ReleaseController(ILogger<StaffController> loger
            , IMapper mapper
            , IApplicationService appService) : base(loger, mapper, appService) { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReleaseToAdd releaseToAdd)
        {
            var release = mapper.Map<Release>(releaseToAdd);
            var result = await appService.Add(release);
            if (result > 0)
            {
                return Ok(release);
            }

            return BadRequest();
        }

        [HttpGet("archived")]
        public IActionResult GetArchived()
        {
            var releases = appService.GetArchivedReleases();
            var releasesToView = mapper.Map<List<ReleaseToView>>(releases);
            return Ok(releasesToView);
        }

        [HttpGet("most-recent")]
        public IActionResult GetMostRecentReleases()
        {
            var releases = appService.GetMostRecentReleases();
            var releaseToView = mapper.Map<List<ReleaseToView>>(releases);
            return Ok(releaseToView);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            var release = appService.GetReleaseById(id);
            return Ok(release);
        }        
    }
}
