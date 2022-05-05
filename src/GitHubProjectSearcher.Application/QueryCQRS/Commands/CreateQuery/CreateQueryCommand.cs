using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;
using MediatR;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery
{
    public class CreateQueryCommand:IRequest<CardListVm>
    {
        public string SearchString { get; set; }
            
    }
}
