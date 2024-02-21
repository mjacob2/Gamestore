using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Genres;

public class UpdateGenreCommand : CommandBase<Genre, Genre>
{
    public override async Task<Genre> Execute(GamestoreDbContext context)
    {
        context.Genres.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
