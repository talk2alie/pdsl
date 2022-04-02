using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Models;
using Pdsl.Api.Services;
using Pdsl.Api.ViewModels;

namespace Pdsl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaffController : AppController
    {
        public StaffController(ILogger<StaffController> loger
            , IMapper mapper
            , IApplicationService appService
        ): base(loger, mapper, appService) { }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StaffToAdd staffToAdd)
        {
            var staff = mapper.Map<Staff>(staffToAdd);
            var result = await appService.Add(staff);
            if (result > 0)
            {
                return Ok(staff);
            }

            return BadRequest();
        }
    }
}
