using FluentValidation;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.DeleteQuery
{
    public class DeleteQueryCommandValidator : AbstractValidator<DeleteQueryCommand>
    {
        public DeleteQueryCommandValidator()
        {
            RuleFor(deleteQueryCommand => deleteQueryCommand.QueryId).NotEmpty();
        }
    }
}
