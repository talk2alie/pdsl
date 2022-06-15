namespace Pdsl.Api.Mailing
{
    public interface IMailingService
    {
        Task SendCodeVerificationEmail(string code);
    }
}
