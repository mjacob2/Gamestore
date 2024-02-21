using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Games;

public class GetAlreadyUsedAliasesQuery : QueryBase<List<string>>
{
    public override async Task<List<string>> Execute(GamestoreDbContext context)
    {
        return await context.Games.Select(x => x.GameAlias).ToListAsync();
    }
}
