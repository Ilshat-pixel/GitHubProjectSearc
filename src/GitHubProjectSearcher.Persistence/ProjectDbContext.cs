using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Domain;
using GitHubProjectSearcher.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GitHubProjectSearcher.Persistence
{
    public class ProjectDbContext : DbContext, IDbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new QueryConfiguration());

        }
        public DbSet<Query> Queries { get; set; }
    }
}
