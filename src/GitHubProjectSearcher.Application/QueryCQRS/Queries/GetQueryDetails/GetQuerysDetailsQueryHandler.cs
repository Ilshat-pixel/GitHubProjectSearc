using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails
{
    public class GetQuerysDetailsQueryHandler : IRequestHandler<GetQuerysDetailsQuery, CardListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetQuerysDetailsQueryHandler(IDbContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CardListVm> Handle(GetQuerysDetailsQuery request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.Queries
                .FirstOrDefaultAsync(query => query.SearchString == request.SearchString, cancellationToken);

            if (query == null)
            {
                var command = new CreateQueryCommand()
                {
                    SearchString = request.SearchString
                };

                var result = await _mediator.Send(command);
                return result;
            }

            return new CardListVm { Cards = _mapper.Map<IList<CardVm>>(query.Cards) };
        }
    }
}
