using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Games;

public class GetGameByAliasQuery : QueryBase<Game>
{
    public required string GameAlias { get; set; }

    public override async Task<Game> Execute(GamestoreDbContext context)
    {
        return await context.Games
            .Where(x => x.GameAlias == GameAlias)
            .Include(x => x.Publisher)
            .Include(x => x.Platforms)
            .Include(x => x.Genres)
            .SingleOrDefaultAsync();
    }
}
