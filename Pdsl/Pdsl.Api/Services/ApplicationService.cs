using AutoMapper;
using Pdsl.Api.Data;
using Pdsl.Api.Models;

namespace Pdsl.Api.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<int> Add(Staff staff)
        {
            staff.Id = $"{Guid.NewGuid()}";
            var employee = mapper.Map<Employee>(staff);

            unitOfWork.EmployeeRepository.Add(employee);
            return unitOfWork.Commit();
        }

        public Task<int> Add(Release release)
        {
            var employee = unitOfWork.EmployeeRepository.GetByLocatorId(release.UploaderId);
            if(employee is null)
            {
                throw new ArgumentException("There is no employee matching the uploader");
            }

            var pressRelease = mapper.Map<PressRelease>(release);
            pressRelease.UploaderId = employee.Id;
            unitOfWork.PressReleaseRepository.Add(pressRelease);
            return unitOfWork.Commit();
        }

        public IEnumerable<Release> GetDisplayableReleases()
        {
            throw new NotImplementedException();
        }

        public Release GetReleaseById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Release> GetReleases()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Release> GetReleasesByStaffId(string staffId)
        {
            throw new NotImplementedException();
        }

        public Staff GetStaffById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStaff(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
