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
            , IVisitorVerificationRepository visitorVerificationRepository
            , ITimedOneTimeAuthenticator authenticator
            , IMailingService mailingService
            , ILogger<VisitorVerificationController> logger)
        {
            this.mapper = mapper;
            this.visitorVerificationRepository = visitorVerificationRepository;
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

            var existingVisitor = FindVisitor(visitorModel);
            if (existingVisitor is not null)
            {
                if (existingVisitor.IsVerified)
                {
                    return AddVisitAndReturnOutputModel(existingVisitor);
                }
                else
                {
                    return await GenerateNewCodeAndReturnOutputModel(existingVisitor);
                }
            }

            return await RegisterNewVisitorFromModel(visitorModel);
        }

        private async Task<IActionResult> RegisterNewVisitorFromModel(RegisterVisitorViewModel visitorModel)
        {
            var cryptoCode = authenticator.GenerateCode();
            var toModel = new CodeVerificationEmailToModel
            {
                Code = cryptoCode.Code.ToString(),
                ToEmail = visitorModel.Email,
                ToName = visitorModel.FullName,
            };
            var response = await mailingService.SendCodeVerificationEmail(toModel);
            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return RegisterNewVisitorAndReturnOutputModel(visitorModel, cryptoCode);
            }

            // Log this issue
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not save visitor registration");
        }

        private IActionResult RegisterNewVisitorAndReturnOutputModel(RegisterVisitorViewModel visitorModel, CryptoCode cryptoCode)
        {
            var newVisitor = new Visitor
                            (
                                NewGuid()
                                , new Name(visitorModel.FullName!)
                                , new Organization(visitorModel.Organization!)
                                , new Email(visitorModel.Email!)
                                , new Secret($"{cryptoCode.Secret}")
                            );
            newVisitor.Add(new Visit(Activity.Register, DateTime.UtcNow));
            newVisitor.Add(new Visit(Activity.RetrieveNewCode, DateTime.UtcNow));
            visitorVerificationRepository.Add(newVisitor);
            if (!visitorVerificationRepository.CommitChanges())
            {
                // Log this issue
            }

            var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(newVisitor);
            visitorOutputModel.IsCodeVerified = false;
            visitorOutputModel.IsCodeSent = true;
            return Ok(visitorOutputModel);
        }

        private async Task<IActionResult> GenerateNewCodeAndReturnOutputModel(Visitor visitor)
        {
            var cryptoCode = authenticator.GenerateCode(visitor.Secret);
            var toModel = new CodeVerificationEmailToModel
            {
                Code = cryptoCode.Code.ToString(),
                ToEmail = visitor.Email.ToString(),
                ToName = visitor.Name.ToString(),
            };
            var sendCodeResponse = await mailingService.SendCodeVerificationEmail(toModel);
            if (sendCodeResponse.StatusCode == HttpStatusCode.Accepted)
            {
                visitor.Add(new Visit(Activity.RetrieveNewCode, DateTime.UtcNow));

                var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(visitor);
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

        private IActionResult AddVisitAndReturnOutputModel(Visitor visitor)
        {
            visitor.Add(new Visit(Activity.Browse, DateTime.UtcNow));
            if (!visitorVerificationRepository.CommitChanges())
            {
                // Log this issue
            }

            var visitorOutputModel = mapper.Map<RegisterVisitorOutputViewModel>(visitor);
            visitorOutputModel.IsCodeVerified = true;
            visitorOutputModel.IsCodeSent = true;
            return Ok(visitorOutputModel);
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
