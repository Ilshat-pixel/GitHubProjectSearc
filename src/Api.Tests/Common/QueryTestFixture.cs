using System;
using System.Net.Http;
using AutoMapper;
using GitHubProjectSearcher.Application.Common.Mappings;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Persistence;
using Xunit;

namespace Api.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ProjectDbContext Context;
        public IMapper Mapper;
        public HttpClient HttpClient;
        public QueryTestFixture()
        {
            Context = QueryContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            QueryContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
