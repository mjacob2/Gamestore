using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Platforms;

public class GetAllPlatformsQuery : QueryBase<List<Platform>>
{
    public override async Task<List<Platform>> Execute(GamestoreDbContext context)
    {
        return await context.Platforms.Include(g => g.Games).ToListAsync();
    }
}
