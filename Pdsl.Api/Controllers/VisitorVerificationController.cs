using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pdsl.Api.Licensing;
using Pdsl.Api.Mailing;
using Pdsl.Api.ViewModels;
using SendGrid;
using System.Net;
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
        public async Task<IActionResult> SendCode([FromBody] RegisterVisitorViewModel visitorModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CryptoCode cryptoCode;
            Response sendCodeResponse;
            CodeVerificationEmailToModel toModel;

            var visitor = FindVisitor(visitorModel);
            if (visitor is not null)
            {
                var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(visitor);
                if (visitor.IsVerified)
                {
                    visitor.Add(new Visit(Activity.Browse, DateTime.UtcNow));
                    if (!visitorVerificationRepository.CommitChanges())
                    {
                        // Log this issue
                    }

                    visitorOutputModel.IsCodeVerified = true;
                    visitorOutputModel.IsCodeSent = true;
                    return Ok(visitorOutputModel);
                }
                else
                {
                    cryptoCode = authenticator.GenerateCode(visitor.Secret);
                    toModel = new CodeVerificationEmailToModel
                    {
                        Code = cryptoCode.Code.ToString(),
                        ToEmail = visitor.Email.ToString(),
                        ToName = visitor.Name.ToString(),
                    };
                    sendCodeResponse = await mailingService.SendCodeVerificationEmail(toModel);
                    if(sendCodeResponse.StatusCode == HttpStatusCode.Accepted)
                    {
                        visitor.Add(new Visit(Activity.RetrieveNewCode, DateTime.UtcNow));
                        visitorOutputModel.IsCodeVerified = false;
                        visitorOutputModel.IsCodeSent = true;
                        if (!visitorVerificationRepository.CommitChanges())
                        {
                            // Log this issue
                        }
                        return Ok(visitorOutputModel);
                    }
                    // Log this issue
                    return StatusCode(StatusCodes.Status500InternalServerError, "Could not send code");
                }
            }

            cryptoCode = authenticator.GenerateCode();
            toModel = new CodeVerificationEmailToModel
            {
                Code = cryptoCode.Code.ToString(),
                ToEmail = visitorModel.Email,
                ToName = visitorModel.FullName,
            };
            var response = await mailingService.SendCodeVerificationEmail(toModel);
            if(response.StatusCode == HttpStatusCode.Accepted)
            {
                visitor = new Visitor
                (
                    NewGuid()
                    , new Name(visitorModel.FullName!)
                    , new Organization(visitorModel.Organization!)
                    , new Email(visitorModel.Email!)
                    , new Secret($"{cryptoCode.Secret}")
                );
                visitor.Add(new Visit(Activity.Register, DateTime.UtcNow));
                visitor.Add(new Visit(Activity.RetrieveNewCode, DateTime.UtcNow));
                visitorVerificationRepository.Add(visitor);
                if (!visitorVerificationRepository.CommitChanges())
                {
                    // Log this issue
                }

                var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(visitor);
                visitorOutputModel.IsCodeVerified = false;
                visitorOutputModel.IsCodeSent = true;
                return Ok(visitorOutputModel);
            }

            // Log this issue
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
                if (!visitorVerificationRepository.CommitChanges())
                {
                    // Log this
                }
                visitorOutputModel.IsCodeVerified = true;
                return Ok(visitorOutputModel);
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
