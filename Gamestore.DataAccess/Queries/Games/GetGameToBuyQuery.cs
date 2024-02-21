using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Games;
public class GetGameToBuyQuery : QueryBase<Game?>
{
    private readonly string _errorMessageWhenNoItemsInStock = "No items in stock of game: }";

    public string GameAlias { get; set; }

    public override async Task<Game?> Execute(GamestoreDbContext context)
    {
        var game = await context.Games
            .Where(x => x.GameAlias == GameAlias)
            .FirstOrDefaultAsync();

        if (game.UnitInStock <= 0)
        {
            throw new NoUnitsInStockException($"{_errorMessageWhenNoItemsInStock} {GameAlias}");
        }

        return game;
    }
}