using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHubProjectSearcher.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace GitHubProjectSearcher.Application.Common.Behaviours
{
    public class CachingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>, ICacheable

    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CachingBehaviour<TRequest, TResponse>> _logger;

        public CachingBehaviour(ILogger<CachingBehaviour<TRequest, TResponse>> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            //_logger.LogInformation("{Request is configured for caching}", requestName);

            TResponse response;
            if (_cache.TryGetValue(request.CacheKey, out response))
            {
                //_logger.LogInformation("Returnin cache value for {Request}", requestName);
                return response;
            }
            //_logger.LogInformation("{Reuest} Cache Key: {Key} is not inside the cache, executing request", requestName,request.CacheKey);
            response = await next();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5));
            _cache.Set(request.CacheKey, response, cacheEntryOptions);
            return response;
        }
    }
}
