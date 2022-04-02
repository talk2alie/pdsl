namespace Pdsl.Api.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PdslDbContext dbContext;

        public EmployeeRepository(PdslDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Employee employee) => dbContext.Employees?.Add(employee);

        public IQueryable<Employee>? Get(Func<Employee, bool>? filter = null)
        {
            if (filter is null)
            {
                return dbContext.Employees;
            }

            return dbContext.Employees?.Where(filter).AsQueryable();
        }

        public Employee? GetByLocatorId(string locatorId) => Get(employee => employee.LocatorId == locatorId)?.FirstOrDefault();

        public void Update(Employee employee) => dbContext.Employees?.Update(employee);
    }
}
