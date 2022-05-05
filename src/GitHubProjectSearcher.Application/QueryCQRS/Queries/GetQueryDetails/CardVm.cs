using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Domain;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails
{
    public class CardVm : IMapWith<Card>
    {
        public OwnerVm Owner { get; set; }
        public string Name { get; set; }
        public int StargazersCount { get; set; }
        public int Watchers { get; set; }
        public string ProjectLink { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Card, CardVm>()
                .ForMember(vm => vm.Owner,
                opt => opt.MapFrom(card => card.Owner))
                .ForMember(vm => vm.StargazersCount,
                opt => opt.MapFrom(card => card.StargazersCount))
                .ForMember(vm => vm.Watchers,
                opt => opt.MapFrom(card => card.Watchers))
                .ForMember(vm => vm.ProjectLink,
                opt => opt.MapFrom(card => card.ProjectLink))
                .ForMember(vm => vm.Name,
                opt => opt.MapFrom(card => card.Name));
        }
    }
}
