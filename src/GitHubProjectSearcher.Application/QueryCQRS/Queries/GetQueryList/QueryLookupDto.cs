using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;
using GitHubProjectSearcher.Domain;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryList
{
    public class QueryLookupDto:IMapWith<Query>
    {
        public int QueryId { get; set; }
        public string SearchString { get; set; }
        public IList<CardVm> Cards { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Query, QueryLookupDto>()
                .ForMember(dto => dto.QueryId,
                opt => opt.MapFrom(q => q.QueryId))
                .ForMember(dto => dto.SearchString,
                opt => opt.MapFrom(q => q.SearchString))
                .ForMember(dto => dto.Cards,
                opt => opt.MapFrom(q => q.Cards.ToList()));
        }
    }
}
