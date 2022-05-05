using System.Reflection;
using FluentValidation;
using GitHubProjectSearcher.Application.Common.Behaviours;
using GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GitHubProjectSearcher.Application
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddHttpClient<CreateQueryCommandHandler>();
            return services;
        }
    }
}
