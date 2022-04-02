using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdsl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReleaseController : AppController
    {
        public ReleaseController(ILogger<StaffController> loger
            , IMapper mapper
            , IApplicationService appService) : base(loger, mapper, appService) { }
    }
}
