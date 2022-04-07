using AutoMapper;
using Pdsl.Bff.Models;
using System.Collections;

namespace Pdsl.Bff.Services
{
    public class PdslService
    {
        private readonly HttpClient httpClient;
        private readonly IMapper mapper;

        public PdslService(HttpClient httpClient, IMapper mapper)
        {
            this.httpClient = httpClient;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ReleaseOutputViewModel>> GetArchivedReleases()
        {
            var url = "release/archived";
            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadFromJsonAsync<List<ReleaseOutputViewModel>>() ?? new List<ReleaseOutputViewModel>();
        }

        public async Task<IEnumerable> GetMostReleases()
        {
            var url = "release/most-recent";
            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadFromJsonAsync<List<ReleaseOutputViewModel>>() ?? new List<ReleaseOutputViewModel>();
        }

        public async Task<ReleaseOutputViewModel?> GetReleaseById(string releaseId)
        {
            var url = $"release/{releaseId}";
            var response = await httpClient.GetAsync(url);

            return await response.Content.ReadFromJsonAsync<ReleaseOutputViewModel>();
        }

        public async Task<ReleaseOutputViewModel?> AddRelease(ReleaseInputViewModel releaseToAdd)
        {
            var url = "release";
            var response = await httpClient.PostAsJsonAsync(url, releaseToAdd);
            
            return await response.Content.ReadFromJsonAsync<ReleaseOutputViewModel>();
        }
    }
}
