using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Licensing;
using Pdsl.Api.ViewModels;

namespace Pdsl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserVerificationController : ControllerBase
    {
        private readonly ITimedOneTimeAuthenticator authenticator;
        private readonly ILogger<UserVerificationController> logger;

        public UserVerificationController(ITimedOneTimeAuthenticator authenticator
            , ILogger<UserVerificationController> logger)
        {
            this.authenticator = authenticator;
            this.logger = logger;
        }

        [HttpPost]
        public IActionResult SendCode([FromBody] UserViewModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cryptoCode = authenticator.GenerateCode();
            var user = new User(
                new UserName(userModel.FullName)
                , new Organization(userModel.Organization)
                , new Email(userModel.Email)
                , new Secret($"{cryptoCode.Secret}")
            );

            return Ok(cryptoCode.Code);
        }
    }
}
