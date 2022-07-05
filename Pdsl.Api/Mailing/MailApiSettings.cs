namespace Pdsl.Api.Mailing
{
    public class MailApiSettings
    {
        public string? CodeVerificationKey { get; set; }

        public string? FromEmail { get; set; }

        public string? FromName { get; set; }

        public string? Subject { get; set; }

        public string? PlainTextContent { get; set; }

        public string? HtmlContent { get; set; }
    }
}
