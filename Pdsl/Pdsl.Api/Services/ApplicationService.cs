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
            release.Id = $"{Guid.NewGuid()}";
            var employee = unitOfWork.EmployeeRepository.GetByLocatorId(release.UploaderId);
            if (employee is null)
            {
                throw new ArgumentException("There is no employee matching the uploader");
            }

            var pressRelease = mapper.Map<PressRelease>(release);
            pressRelease.UploaderId = employee.Id;
            unitOfWork.PressReleaseRepository.Add(pressRelease);
            return unitOfWork.Commit();
        }

        public IEnumerable<Release> GetMostRecentReleases()
        {
            var forteenDaysAgo = DateTime.UtcNow.AddDays(-14);
            var todaysDate = DateTime.UtcNow;

            var frontPagePressReleases = unitOfWork.PressReleaseRepository
                                                   .Get(pr => pr.ReleaseDate >= forteenDaysAgo && pr.ReleaseDate <= todaysDate)
                                                   ?.OrderByDescending(r => r.ReleaseDate)
                                                   ?.ToList();
            if(frontPagePressReleases is null)
            {
                return new List<Release>();
            }

            var frontPageReleases = mapper.Map<List<Release>>(frontPagePressReleases);
            return frontPageReleases;
        }

        public Release GetReleaseById(string id)
        {
            var pressRelease = unitOfWork.PressReleaseRepository.Get(pr => pr.LocatorId == id)?.FirstOrDefault();
            if(pressRelease is null)
            {
                throw new ArgumentException($"There is no press release with the id, {id}", nameof(id));
            }

            var release = mapper.Map<Release>(pressRelease);
            return release;
        }

        public IEnumerable<Release> GetArchivedReleases()
        {
            var oneYearAgo = DateTime.UtcNow.AddYears(-1);
            var forteenDaysAgo = DateTime.UtcNow.AddDays(-14);

            var pressReleases = unitOfWork.PressReleaseRepository
                                          .Get(pr => pr.ReleaseDate >= oneYearAgo && pr.ReleaseDate < forteenDaysAgo)
                                          ?.OrderByDescending(pr => pr.ReleaseDate)
                                          ?.ToList();
            if(pressReleases is null)
            {
                return new List<Release>();
            }

            var releases = mapper.Map<List<Release>>(pressReleases);
            return releases;
        }

        public IEnumerable<Release> GetReleasesByStaffId(string staffId)
        {
            var uploader = unitOfWork.EmployeeRepository.GetByLocatorId(staffId);
            if(uploader is null)
            {
                throw new ArgumentException($"There is no employee with id, {staffId}");
            }

            var releases = new List<Release>();

            var pressReleases = unitOfWork.PressReleaseRepository.Get(pr => pr.UploaderId == uploader.Id)?.ToList();
            if(pressReleases is null || pressReleases.Count == 0)
            {
                return releases;
            }

            releases = mapper.Map<List<Release>>(pressReleases);
            return releases;
        }
    }
}
