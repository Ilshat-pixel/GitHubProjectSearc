using System.Reflection;
using GitHubProjectSearcher.Api.Extensions;
using GitHubProjectSearcher.Api.Middleware;
using GitHubProjectSearcher.Application;
using GitHubProjectSearcher.Application.Common.Mappings;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GitHubProjectSearcher.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IDbContext).Assembly));
            });
            services.AddAuthServices();
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();
            services.AddSwaggerDocumentation("GitHubProjectSearcher.Api", "v1", "https://localhost:7260/connect/token");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation("GitHubProjectSearcher Documentation", "GitHubProjectSearcher.Api v1", "/swagger/v1/swagger.json", "client_id_search_service", "client_secret_search_service");

            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
