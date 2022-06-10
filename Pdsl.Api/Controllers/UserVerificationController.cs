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
        [Route("send")]
        public IActionResult SendCode([FromBody] UserViewModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cryptoCode = authenticator.GenerateCode();
            var user = new Visitor(
                new Name(userModel.FullName!)
                , new Organization(userModel.Organization!)
                , new Email(userModel.Email!)
                , new Secret($"{cryptoCode.Secret}")
            );

            return Ok(cryptoCode.Code);
        }

        [HttpPost]
        [Route("verify")]
        public IActionResult VerifyCode([FromBody] VerifyCodeUserViewModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var secret = $"{authenticator.GenerateCode().Secret}";
            var user = new Visitor
            (
                new Name(userModel.FullName!),
                new Organization(userModel.Organization!),
                new Email(userModel.Email!),
                new Secret(secret)
            );
            var codeIsValid = authenticator.UserCodeIsValid(user, new CryptoCode(new Secret(secret), new Code(userModel.Code!)));
            if(codeIsValid)
            {
                user.IsVerified = codeIsValid;
                return Ok(codeIsValid);
            }

            return BadRequest("Code is invalid");
        }
    }
}
