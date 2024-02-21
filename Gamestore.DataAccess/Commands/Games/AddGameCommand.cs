using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Games;

public class AddGameCommand : CommandBase<Game, Game>
{
    public override async Task<Game> Execute(GamestoreDbContext context)
    {
        await context.Games.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
