namespace Pdsl.Api.Licensing
{
    public interface ITimedOneTimeAuthenticator
    {
        CryptoCode GenerateCode();

        bool UserCodeIsValid(Visitor user, CryptoCode code);
    }
}
