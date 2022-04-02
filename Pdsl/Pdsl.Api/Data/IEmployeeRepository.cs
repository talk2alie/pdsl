namespace Pdsl.Api.Data
{
    public interface IEmployeeRepository
    {
        public Task<Employee> GetByLocatorId(string locatorId);
        public Task<IEnumerable<Employee>> GetAll();
        public Task<int> Add(Employee employee);
        public Task<int> Update(Employee employee);
    }
}
