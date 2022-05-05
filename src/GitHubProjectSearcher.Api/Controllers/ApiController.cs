using System.Threading.Tasks;
using GitHubProjectSearcher.Application.QueryCQRS.Commands.DeleteQuery;
using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;
using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitHubProjectSearcher.Api.Controllers
{

    [Produces("application/json")]
    [Route("api")]
    public class ApiController : BaseController
    {
        /// <summary>
        /// Return project by search string
        /// </summary>
        /// <param name="searchString">Search String</param>
        /// <returns> Return projects</returns>
        /// <response code="200">Success</response>
        [HttpPost("find")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromForm] string searchString)
        {
            var query = new GetQuerysDetailsQuery
            {
                SearchString = searchString,
                CacheKey = searchString
            };
            var cards = await Mediator.Send(query);
            return Ok(cards);
        }
        [HttpGet("find")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetQueryListQuery { };
            var vm = await Mediator.Send(query);
            return Ok(vm);

        }

        [HttpDelete("find")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteQueryCommand
            {
                QueryId = Id
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
