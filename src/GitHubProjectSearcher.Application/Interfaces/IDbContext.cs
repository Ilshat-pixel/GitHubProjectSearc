
using GitHubProjectSearcher.Domain;
using Microsoft.EntityFrameworkCore;

namespace GitHubProjectSearcher.Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Query> Queries { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
