using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Platforms;
public class GetPlatformsByIdsQuery : QueryBase<List<Platform>>
{
    public required List<int> PlatformsIds { get; set; }

    public override async Task<List<Platform>> Execute(GamestoreDbContext context)
    {
        return await context.Platforms.Where(g => PlatformsIds.Contains(g.Id)).ToListAsync();
    }
}
