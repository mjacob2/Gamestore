using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Platforms;

public class GetPlatformByIdQuery : QueryBase<Platform?>
{
    public int PlatformId { get; set; }

    public override async Task<Platform?> Execute(GamestoreDbContext context)
    {
        return await context.Platforms
            .Include(x => x.Games)
            .SingleOrDefaultAsync(x => x.Id == PlatformId);
    }
}
