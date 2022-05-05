using FluentValidation;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery
{
    public class CreateQueryCommandValidator : AbstractValidator<CreateQueryCommand>
    {
        public CreateQueryCommandValidator()
        {
            RuleFor(createQueryCommand => createQueryCommand.SearchString).NotEmpty();
        }
    }
}
