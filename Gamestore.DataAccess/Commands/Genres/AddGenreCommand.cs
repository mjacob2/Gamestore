using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Genres;

public class AddGenreCommand : CommandBase<Genre, Genre>
{
    public override async Task<Genre> Execute(GamestoreDbContext context)
    {
        await context.Genres.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
