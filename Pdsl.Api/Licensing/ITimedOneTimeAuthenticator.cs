namespace Pdsl.Api.Licensing
{
    public interface ITimedOneTimeAuthenticator
    {
        CryptoCode GenerateCode();

        CryptoCode GenerateCode(Secret secret);

        bool UserCodeIsValid(Visitor user, CryptoCode code);
    }
}
