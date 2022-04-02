using AutoMapper;
using Pdsl.Api.Data;
using Pdsl.Api.Models;
using Pdsl.Api.ViewModels;

namespace Pdsl.Api.Profiles
{
    public class AppProfiles : Profile
    {
        public AppProfiles()
        {
            CreateMap<Staff, Employee>()
                .ForMember(e => e.Id, options => options.Ignore())
                .ForMember(e => e.LocatorId, option => option.MapFrom(s => s.Id))
                .ForMember(e => e.PressReleases, option => option.Ignore())
                .ReverseMap();

            CreateMap<Release, PressRelease>()
                .ForMember(pr => pr.Id, options => options.Ignore())
                .ForMember(pr => pr.Abstract, options => options.MapFrom(r => r.Description))
                .ForMember(pr => pr.HeroImageFilePath, options => options.MapFrom(r => r.BannerImagePath))
                .ForMember(pr => pr.DataFilePath, options => options.MapFrom(r => r.FilePath))
                .ForMember(pr => pr.LocatorId, options => options.MapFrom(r => r.Id))
                .ForMember(pr => pr.UploaderId, options => options.Ignore())
                .ReverseMap();

            CreateMap<StaffToAdd, Staff>()
                .ForMember(s => s.Title, options => options.MapFrom(sta => sta.Position))
                .ReverseMap();

            CreateMap<ReleaseToAdd, Release>()
                .ReverseMap();
        }
    }
}
