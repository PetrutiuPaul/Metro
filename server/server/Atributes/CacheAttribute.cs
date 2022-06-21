using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using server.Cache;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace server.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLive;

        public CacheAttribute(int timeToLive)
        {
            _timeToLive = timeToLive;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetService(typeof(ICacheService)) as ICacheService;

            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = cacheService.Get(cacheKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };

                context.Result = contentResult;

                return;
            }

            var executedContext = await next();

            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                cacheService.Set(cacheKey, okObjectResult.Value, _timeToLive);
            }
        }

        private static string GenerateCacheKeyFromRequest(Microsoft.AspNetCore.Http.HttpRequest request)
        {
            var keyBuilder = new System.Text.StringBuilder();

            keyBuilder.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }

            return keyBuilder.ToString();
        }
    }
}
