using FluentValidation;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails
{
    public class GetQuerysDetailsQueryValidator : AbstractValidator<GetQuerysDetailsQuery>
    {
        public GetQuerysDetailsQueryValidator()
        {
            RuleFor(x => x.SearchString).NotEmpty();
        }
    }
}
