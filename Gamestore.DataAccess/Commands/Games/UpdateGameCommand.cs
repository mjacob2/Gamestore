using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Games;

public class UpdateGameCommand : CommandBase<Game, Game>
{
    public override async Task<Game> Execute(GamestoreDbContext context)
    {
        context.Games.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}