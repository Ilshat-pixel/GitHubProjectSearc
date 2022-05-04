using MediatR;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.DeleteQuery
{
    public class DeleteQueryCommand:IRequest
    {
        public int QueryId { get; set; }
    }
}
