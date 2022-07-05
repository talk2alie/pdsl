using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Pdsl.Api.Mailing
{
    public class MailingService : IMailingService
    {
        private readonly MailApiSettings mailApiSettings;

        public MailingService(IOptions<MailApiSettings> mailApiSettings)
        {
            this.mailApiSettings = mailApiSettings.Value;
        }

        public Task<Response> SendCodeVerificationEmail(CodeVerificationEmailToModel toModel)
        {
            var client = new SendGridClient(mailApiSettings.CodeVerificationKey);
            var from = new EmailAddress(mailApiSettings.FromEmail, mailApiSettings.FromName);
            var subject = mailApiSettings.Subject;
            var to = new EmailAddress(toModel.ToEmail, toModel.ToName);
            var plainTextContent = mailApiSettings.PlainTextContent?.Replace("##Code##", toModel.Code);
            var htmlContent = mailApiSettings.HtmlContent?.Replace("##Code##", toModel.Code);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            return client.SendEmailAsync(msg);
        }
    }
}
