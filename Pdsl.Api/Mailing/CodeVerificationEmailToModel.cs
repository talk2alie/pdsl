namespace Pdsl.Api.Mailing
{
    public class CodeVerificationEmailToModel
    {
        public string? ToName { get; set; }

        public string? ToEmail { get; set; }

        public string? Code { get; set; }
    }
}
