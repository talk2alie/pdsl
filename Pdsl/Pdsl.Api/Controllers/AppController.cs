using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Services;

namespace Pdsl.Api.Controllers
{
    public class AppController : ControllerBase
    {
        protected ILogger<StaffController> logger { get; }
        protected IMapper mapper { get; }
        protected IApplicationService appService { get; }

        public AppController(ILogger<StaffController> loger
            , IMapper mapper
            , IApplicationService appService)
        {
            this.logger = loger;
            this.mapper = mapper;
            this.appService = appService;
        }
    }
}
