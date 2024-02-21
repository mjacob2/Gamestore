using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Services.GameHandlerService;
public interface IGameHandlerService
{
    Task<Game> GetGameToUpdateFromRequest(UpdateGameRequest request);

    Task<Game> GetGameToAddFromRequest(AddGameRequest request);

    Task<bool> IsGameAliasAlreadyTaken(string gameAlias);
}
