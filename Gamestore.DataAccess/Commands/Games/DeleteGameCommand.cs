using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Games;

public class DeleteGameCommand : CommandBase<Game, Game>
{
    public override async Task<Game> Execute(GamestoreDbContext context)
    {
        context.Games.Remove(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
