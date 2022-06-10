namespace Pdsl.Api.Licensing
{
    public interface ITimedOneTimeAuthenticator
    {
        CryptoCode GenerateCode();

        bool UserCodeIsValid(User user, CryptoCode code);
    }
}
