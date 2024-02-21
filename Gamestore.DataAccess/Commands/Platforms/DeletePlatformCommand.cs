using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Commands.Platforms;

public class DeletePlatformCommand : CommandBase<Platform, Platform>
{
    public override async Task<Platform> Execute(GamestoreDbContext context)
    {
        var hasGamesAssociated = await context.Games.AnyAsync(g => g.PlatformId == Parameter.Id);

        if (hasGamesAssociated)
        {
            throw new ConflictException("Can't delete this Platform, because some Games realy on this.");
        }

        context.Platforms.Remove(Parameter);
        await context.SaveChangesAsync();

        return Parameter;
    }
}
