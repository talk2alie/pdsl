namespace Pdsl.Api.Data
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IPressReleaseRepository PressReleaseRepository { get; }
        public Task<int> Commit();
    }
}
