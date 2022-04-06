﻿using Pdsl.Api.Models;

namespace Pdsl.Api.Services
{
    public interface IApplicationService
    {
        public Task<int> Add(Staff staff);

        public Task<int> Add(Release release);
        public IEnumerable<Release> GetArchivedReleases();
        public IEnumerable<Release> GetMostRecentReleases();
        public Release GetReleaseById(string id);
        public IEnumerable<Release> GetReleasesByStaffId(string staffId);
    }
}
