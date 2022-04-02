namespace Pdsl.Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PdslDbContext dbContext;

        public IEmployeeRepository EmployeeRepository { get; }

        public IPressReleaseRepository PressReleaseRepository { get; }

        public UnitOfWork(PdslDbContext dbContext)
        {
            this.dbContext = dbContext;
            EmployeeRepository ??= new EmployeeRepository(dbContext);
            PressReleaseRepository ??= new PressReleaseRepository(dbContext);
        }

        public Task<int> Commit() => dbContext.SaveChangesAsync();
    }
}
