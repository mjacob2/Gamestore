using Gamestore.DataAccess;
using Microsoft.Extensions.Caching.Memory;

namespace Gamestore.API.Middleware;

public class GamesCountMiddleware : IMiddleware
{
    private readonly GamestoreDbContext _dbContext;
    private readonly IMemoryCache _cache;

    public GamesCountMiddleware(GamestoreDbContext dbContext, IMemoryCache cache)
    {
        _dbContext = dbContext;
        _cache = cache;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!_cache.TryGetValue("GamesCountKey", out int gamesCount))
        {
            gamesCount = _dbContext.Games.Count();
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                Priority = CacheItemPriority.High,
            };

            _cache.Set("GamesCountKey", gamesCount, cacheOptions);
        }

        context.Response.OnStarting(
            state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers.Add("X-Games-Count", gamesCount.ToString());
                return Task.CompletedTask;
            },
            context);

        await next(context);
    }
}