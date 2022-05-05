using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;

namespace GitHubProjectSearcher.Web.Models
{
    public class SearchModelDto
    {
        public string SeachString { get; set; }
        public CardListVm Cards { get; set; }
    }
}
