namespace Pdsl.Api.Data
{
    public interface IEmployeeRepository
    {
        public Employee? GetByLocatorId(string locatorId);
        public IQueryable<Employee>? Get(Func<Employee, bool>? filter);
        public void Add(Employee employee);
        public void Update(Employee employee);
    }
}
