using MediatR;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryList
{
    public class GetQueryListQuery:IRequest<QueryListVm>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
