using AutoMapper;
using Pdsl.Api.Licensing;
using Pdsl.Api.ViewModels;

namespace Pdsl.Api.Profiles
{
    public class VisitorToVisitorOutputViewModel : Profile
    {
        public VisitorToVisitorOutputViewModel()
        {
            CreateMap<Visitor, VisitorOutputViewModel>()
                .ForMember(vm => vm.Email, c => c.MapFrom(v => v.Email.Text))
                .ForMember(vm => vm.FullName, c => c.MapFrom(v => v.Name.Text))
                .ForMember(vm => vm.Organization, c => c.MapFrom(v => v.Organization.Name));
        }
    }
}
