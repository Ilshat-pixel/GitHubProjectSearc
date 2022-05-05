using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Tests.Common;
using GitHubProjectSearcher.Application.Common.Exceptions;
using GitHubProjectSearcher.Application.QueryCQRS.Commands.DeleteQuery;
using Xunit;

namespace Api.Tests.Query.Commands
{
    public class DeleteQueryCommandTests:TestCommandBase
    {
        [Fact]
        public async Task DeleteQueryCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteQueryCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteQueryCommand
            {
                QueryId = QueryContextFactory.QueryIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Queries.SingleOrDefault(query =>
                query.QueryId == QueryContextFactory.QueryIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteQueryCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteQueryCommand
                    {
                        QueryId =  10
                    },
                    CancellationToken.None));
        }

  
    }
}
