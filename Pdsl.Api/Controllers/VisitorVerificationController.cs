using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Licensing;
using Pdsl.Api.Mailing;
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
        private readonly IMailingService mailingService;
        private readonly ILogger<VisitorVerificationController> logger;

        public VisitorVerificationController(IMapper mapper
            , IVisitorVerificationRepository userVerificationRepository
            , ITimedOneTimeAuthenticator authenticator
            , IMailingService mailingService
            , ILogger<VisitorVerificationController> logger)
        {
            this.mapper = mapper;
            this.visitorVerificationRepository = userVerificationRepository;
            this.authenticator = authenticator;
            this.mailingService = mailingService;
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
                var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(visitor);
                if (visitor.IsVerified)
                {
                    visitor.Add(new Visit(Activity.Browse, DateTime.UtcNow));
                    if (visitorVerificationRepository.CommitChanges())
                    {
                        visitorOutputModel.IsVerified = true;
                        visitorOutputModel.IsCodeSent = true;
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
                        visitorOutputModel.IsVerified = false;
                        visitorOutputModel.IsCodeSent = true;
                        // Send email and return visitor output model
                        return Ok(visitorOutputModel);
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
                var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(visitor);
                visitorOutputModel.IsVerified = false;
                visitorOutputModel.IsCodeSent = true;
                return Ok(visitorOutputModel);
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

            var visitorOutputModel = mapper.Map<VerifyCodeVisitorOutputModel>(visitor);
            var codeIsValid = authenticator.UserCodeIsValid(visitor,
                new CryptoCode(visitor.Secret, new Code(userModel.Code!)));
            if (codeIsValid)
            {
                visitor.IsVerified = true;
                visitor.Secret = new Secret(string.Empty);
                visitor.Add(new Visit(Activity.Verify, DateTime.UtcNow));
                if (visitorVerificationRepository.CommitChanges())
                {
                    visitorOutputModel.IsCodeVerified = true;
                    return Ok(visitorOutputModel);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Could not update visitor's verification status");
            }

            visitorOutputModel.IsCodeVerified = false;
            return BadRequest(visitorOutputModel);
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
