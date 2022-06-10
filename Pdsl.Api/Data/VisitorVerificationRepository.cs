using Pdsl.Api.Licensing;

namespace Pdsl.Api.Data
{
    public class VisitorVerificationRepository : IVisitorVerificationRepository
    {
        private readonly PdslDbContext context;

        public VisitorVerificationRepository(PdslDbContext context)
        {
            this.context = context ?? new PdslDbContext();
        }

        public void Add(Visitor visitor)
        {
            
            context.Visitors?.Add(visitor);
        }

        public bool CommitChanges()
        {
            return context.SaveChanges() > 0;
        }

        public Visitor? FindByValue(FindVisitorModel visitor)
        {
            return context.Visitors?.SingleOrDefault(v => 
             v.Name == visitor.Name 
             && v.Organization == visitor.Organization
             && v.Email == visitor.Email);
        }

        public Visitor? Get(Guid id) => context.Visitors?.SingleOrDefault(visitor => visitor.Id == id);
    }
}
