using GitHubProjectSearcher.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubProjectSearcher.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IDbContext>(provider =>
            provider.GetService<ProjectDbContext>());

            return services;
        }
    }
}
