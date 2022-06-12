using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Licensing;
using Pdsl.Api.ViewModels;
using static System.Guid;

namespace Pdsl.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VisitorVerificationController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IVisitorVerificationRepository visitorVerificationRepository;
        private readonly ITimedOneTimeAuthenticator authenticator;
        private readonly ILogger<VisitorVerificationController> logger;

        public VisitorVerificationController(IMapper mapper
            , IVisitorVerificationRepository userVerificationRepository
            , ITimedOneTimeAuthenticator authenticator
            , ILogger<VisitorVerificationController> logger)
        {
            this.mapper = mapper;
            this.visitorVerificationRepository = userVerificationRepository;
            this.authenticator = authenticator;
            this.logger = logger;
        }

        [HttpPost]
        [Route("send")]
        public IActionResult SendCode([FromBody] RegisterVisitorViewModel visitorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CryptoCode cryptoCode;

            var visitor = FindVisitor(visitorModel);
            if (visitor is not null)
            {
                if (visitor.IsVerified)
                {
                    visitor.Add(new Visit(Activity.Browse, DateTime.UtcNow));
                    if (visitorVerificationRepository.CommitChanges())
                    {
                        var visitorOutputModel = mapper.Map<VisitorOutputViewModel>(visitor);
                        return Ok(visitorOutputModel);
                    }
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not save visitor visit");
                }
                else
                {
                    cryptoCode = authenticator.GenerateCode(visitor.Secret);
                    visitor.Add(new Visit(Activity.RetrieveNewCode, DateTime.UtcNow));
                    if (visitorVerificationRepository.CommitChanges())
                    {
                        // Send email and return status
                        return Ok(cryptoCode.Code);
                    }
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not save visitor visit");
                }
            }

            cryptoCode = authenticator.GenerateCode();
            visitor = new Visitor
            (
                NewGuid()
                , new Name(visitorModel.FullName!)
                , new Organization(visitorModel.Organization!)
                , new Email(visitorModel.Email!)
                , new Secret($"{cryptoCode.Secret}")
            );
            visitor.Add(new Visit(Activity.Register, DateTime.UtcNow));
            visitorVerificationRepository.Add(visitor);
            if (visitorVerificationRepository.CommitChanges())
            {
                // Send email and return status
                return Ok(cryptoCode.Code);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Could not save visitor registration");
        }

        [HttpPost]
        [Route("verify")]
        public IActionResult VerifyCode([FromBody] VerifyCodeVisitorViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var visitor = FindVisitor(userModel);
            if (visitor is null)
            {
                return NotFound();
            }

            var codeIsValid = authenticator.UserCodeIsValid(visitor,
                new CryptoCode(visitor.Secret, new Code(userModel.Code!)));
            if (codeIsValid)
            {
                visitor.IsVerified = true;
                visitor.Secret = new Secret(string.Empty);
                visitor.Add(new Visit(Activity.Verify, DateTime.UtcNow));
                if (visitorVerificationRepository.CommitChanges())
                {
                    var visitorOutputModel = mapper.Map<VisitorOutputViewModel>(visitor);
                    return Ok(visitorOutputModel);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not update visitor's verification status");
            }

            return BadRequest("Code is invalid");
        }

        private Visitor? FindVisitor(VisitorViewModel model)
        {
            var name = new Name(model.FullName!);
            var organization = new Organization(model.Organization!);
            var email = new Email(model.Email!);
            var visitor = visitorVerificationRepository.FindByValue(new FindVisitorModel(name, organization, email));
            return visitor;
        }
    }
}
