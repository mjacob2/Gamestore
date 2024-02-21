using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Comments;
public class GetCommentsByGameAliasQuery : QueryBase<List<Comment>>
{
    public required string GameAlias { get; set; }

    public override async Task<List<Comment>> Execute(GamestoreDbContext context)
    {
        return await context.Comments
            .Where(c => c.GameAlias == GameAlias)
            .ToListAsync();
    }
}
