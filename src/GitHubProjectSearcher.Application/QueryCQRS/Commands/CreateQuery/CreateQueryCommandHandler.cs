using AutoMapper;
using GitHubProjectSearcher.Application.Interfaces;
using GitHubProjectSearcher.Application.QueryCQRS.Queries.GetQueryDetails;
using GitHubProjectSearcher.Domain;
using MediatR;
using Newtonsoft.Json;
using QuickType;

namespace GitHubProjectSearcher.Application.QueryCQRS.Commands.CreateQuery
{
    public class CreateQueryCommandHandler : IRequestHandler<CreateQueryCommand, CardListVm>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;



        public CreateQueryCommandHandler(IDbContext dbContext, IMapper mapper, IHttpClientFactory iHttpClientFactory)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpClient = iHttpClientFactory.CreateClient();
        }
        //TODO: вынести вызов апи в отдельный метод
        public async Task<CardListVm> Handle(CreateQueryCommand request, CancellationToken cancellationToken)
        {
            var uri = String.Concat("https://api.github.com/search/repositories?q=", request.SearchString);
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"
            var result = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);
            result.EnsureSuccessStatusCode(); // throws if not 200-299
            var aaa = new JsonQuery();
            if (result.Content is object && result.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await result.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    aaa = serializer.Deserialize<JsonQuery>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }
            var card = _mapper.Map<IList<Card>>(aaa.Items);
            var query = new Query
            {
                SearchString = request.SearchString,
                Cards = card,

            };
            _dbContext.Queries.Add(query);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new CardListVm { Cards = _mapper.Map<IList<CardVm>>(query.Cards) };
        }

    }
}
