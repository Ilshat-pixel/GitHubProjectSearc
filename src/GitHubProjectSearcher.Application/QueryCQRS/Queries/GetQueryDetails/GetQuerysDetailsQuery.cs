using GitHubProjectSearcher.Application.Interfaces;
using MediatR;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails
{
    public class GetQuerysDetailsQuery:IRequest<CardListVm>,ICacheable
    {
        public string SearchString { get; set; }

        public string CacheKey { get; set; }
    }
}
