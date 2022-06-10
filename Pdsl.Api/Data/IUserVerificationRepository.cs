using Pdsl.Api.Licensing;

namespace Pdsl.Api.Data
{
    public interface IUserVerificationRepository
    {
        void Add(Visitor user);

        Visitor Get(string id);

        bool CommitChanges();
    }
}
