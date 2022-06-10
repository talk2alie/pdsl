namespace Pdsl.Api.Licensing
{
    public interface IUserVerificationRepository
    {
        void Add(Visitor user);

        Visitor Get(string id);

        bool CommitChanges();
    }
}
