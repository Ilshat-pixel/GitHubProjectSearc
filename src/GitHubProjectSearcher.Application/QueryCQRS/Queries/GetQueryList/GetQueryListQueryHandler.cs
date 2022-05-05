using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GitHubProjectSearcher.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryList
{
    public class GetQueryListQueryHandler : IRequestHandler<GetQueryListQuery, QueryListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetQueryListQueryHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<QueryListVm> Handle(GetQueryListQuery request, CancellationToken cancellationToken)
        {
            var querys =  _dbContext.Queries
                .Skip(request.Page)
                .Take(request.PageSize)
                .AsEnumerable().ToList();
            var dtoList = _mapper.Map<IList<QueryLookupDto>>(querys);
            return new QueryListVm { Querys = dtoList };
        }
    }
}
