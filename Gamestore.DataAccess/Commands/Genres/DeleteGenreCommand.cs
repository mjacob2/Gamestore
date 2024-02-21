using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Commands.Genres;

public class DeleteGenreCommand : CommandBase<Genre, Genre>
{
    public override async Task<Genre> Execute(GamestoreDbContext context)
    {
        var hasGamesAssociated = await context.Games.AnyAsync(g => g.Genres.Any(gn => gn.Id == Parameter.Id));

        if (hasGamesAssociated)
        {
            throw new ConflictException("Can't delete this Genre, because some Games rely on this.");
        }

        context.Genres.Remove(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
