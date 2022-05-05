using System.Diagnostics;
using System.Threading.Tasks;
using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;
using GitHubProjectSearcher.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitHubProjectSearcher.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(SearchModelDto searchModelDto)
        {
            if (!string.IsNullOrEmpty(searchModelDto.SeachString))
            {
                var query = new GetQuerysDetailsQuery
                {
                    SearchString = searchModelDto.SeachString,
                    CacheKey = searchModelDto.SeachString
                };
                var cards = await Mediator.Send(query);
                searchModelDto.Cards = cards;
            }

            return View(searchModelDto);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
