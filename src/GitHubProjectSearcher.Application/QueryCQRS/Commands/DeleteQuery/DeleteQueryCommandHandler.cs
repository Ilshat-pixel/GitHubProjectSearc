using GitHubProjectSearcher.Application.Common.Exceptions;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Domain;
using MediatR;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.DeleteQuery
{
    public class DeleteQueryCommandHandler : IRequestHandler<DeleteQueryCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteQueryCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteQueryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Queries
                .FindAsync(new object[] { request.QueryId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Query), request.QueryId);

            }

            _dbContext.Queries.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
