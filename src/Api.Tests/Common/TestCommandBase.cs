using System;
using GitHubProjectSearcher.Persistence;

namespace Api.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ProjectDbContext Context;

        public TestCommandBase()
        {
            Context = QueryContextFactory.Create();
        }

        public void Dispose()
        {
            QueryContextFactory.Destroy(Context);
        }
    }
}
