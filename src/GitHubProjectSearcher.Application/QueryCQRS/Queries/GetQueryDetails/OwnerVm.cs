using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Domain;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails
{
    public class OwnerVm : IMapWith<Owner>
    {
        public int OwnerId { get; set; }
        public string Login { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Owner, OwnerVm>()
                .ForMember(vm => vm.OwnerId,
                opt => opt.MapFrom(owner => owner.OwnerId))
                .ForMember(vm => vm.Login,
                opt => opt.MapFrom(owner => owner.Login));
        }
    }
}
