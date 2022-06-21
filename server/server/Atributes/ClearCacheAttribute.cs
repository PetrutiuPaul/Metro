using Microsoft.AspNetCore.Mvc.Filters;
using server.Cache;
using System;
using System.Threading.Tasks;

namespace server.Atributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ClearCacheAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheService = context.HttpContext.RequestServices.GetService(typeof(ICacheService)) as ICacheService;

            await next();

            cacheService.Clear();
        }
    }
}
