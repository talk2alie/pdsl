using SendGrid;

namespace Pdsl.Api.Mailing
{
    public interface IMailingService
    {
        Task<Response> SendCodeVerificationEmail(CodeVerificationEmailToModel toModel);
    }
}
