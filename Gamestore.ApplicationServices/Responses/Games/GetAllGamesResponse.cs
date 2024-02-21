using Gamestore.ApplicationServices.Models;

namespace Gamestore.ApplicationServices.Responses.Games;

public class GetAllGamesResponse : ResponseBase<List<GameListingModel>>
{
    public int TotalCount { get; set; }
}
