namespace Pdsl.Api.Licensing
{
    public interface IVisitorVerificationRepository
    {
        void Add(Visitor visitor);

        Visitor? Get(Guid id);

        Visitor? FindByValue(FindVisitorModel visitor);

        bool CommitChanges();
    }
}
