using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.ApplicationServices.Services.GameHandlerService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;

public class AddGameHandler : IRequestHandler<AddGameRequest, AddGameResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IGameHandlerService _gameService;

    public AddGameHandler(ICommandExecutor commandExecutor, IGameHandlerService gameService)
    {
        _commandExecutor = commandExecutor;
        _gameService = gameService;
    }

    public async Task<AddGameResponse> Handle(AddGameRequest request, CancellationToken cancellationToken)
    {
        var gameToAdd = await _gameService.GetGameToAddFromRequest(request);

        gameToAdd.CreationDate = DateTime.UtcNow;

        AddGameCommand addNewGameCommand = new() { Parameter = gameToAdd };

        await _commandExecutor.ExecuteCommand(addNewGameCommand);

        var response = new AddGameResponse() { Data = request };

        return response;
    }
}
