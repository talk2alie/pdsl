using Microsoft.Extensions.Options;

namespace Pdsl.Api.Mailing
{
    public class MailingService : IMailingService
    {
        private readonly MailApiSettings mailApiSettings;

        public MailingService(IOptions<MailApiSettings> mailApiSettings)
        {
            this.mailApiSettings = mailApiSettings.Value;
        }

        public Task SendCodeVerificationEmail(string code)
        {
            throw new NotImplementedException();
        }
    }
}
