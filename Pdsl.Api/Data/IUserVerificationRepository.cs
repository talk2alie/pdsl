using Pdsl.Api.Licensing;

namespace Pdsl.Api.Data
{
    public interface IUserVerificationRepository
    {
        void Add(User user);

        User Get(string id);

        bool CommitChanges();
    }
}
