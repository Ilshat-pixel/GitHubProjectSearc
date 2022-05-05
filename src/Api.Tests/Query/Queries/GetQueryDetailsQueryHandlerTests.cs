using System.Threading;
using System.Threading.Tasks;
using Api.Tests.Common;
using AutoMapper;
using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;
using GitHubProjectSearcher.Persistence;
using Shouldly;
using Xunit;

namespace Api.Tests.Query.Queries
{
    [Collection("QueryCollection")]
    //TODO:доделать тест
    public class GetQueryDetailsQueryHandlerTests
    {
        //private readonly ProjectDbContext Context;
        //private readonly IMapper Mapper;

        //public GetQueryDetailsQueryHandlerTests(QueryTestFixture fixture)
        //{
        //    Context = fixture.Context;
        //    Mapper = fixture.Mapper;
        //}

        //[Fact]
        //public async Task GetQueryDetailsQueryHandler_Success()
        //{
        //    // Arrange
        //    var handler = new GetQuerysDetailsQueryHandler(Context, Mapper);

        //    // Act
        //    var result = await handler.Handle(
        //        new GetQuerysDetailsQuery
        //        {
        //            SearchString="2",
        //            CacheKey = "2",
        //        },
        //        CancellationToken.None);

        //    // Assert
        //    result.ShouldBeOfType<CardListVm>();
        //    result.Cards[0].Name.ShouldBe("2");
        //    result.Cards[0].StargazersCount.ShouldBe(2);
        //}
    }
}
