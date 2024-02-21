using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.ApplicationServices.Services.GameHandlerService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;

public class UpdateGameHandler : IRequestHandler<UpdateGameRequest, UpdateGameResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IGameHandlerService _gameService;

    public UpdateGameHandler(ICommandExecutor commandExecutor, IGameHandlerService gameService)
    {
        _commandExecutor = commandExecutor;
        _gameService = gameService;
    }

    public async Task<UpdateGameResponse> Handle(UpdateGameRequest request, CancellationToken cancellationToken)
    {
        var updatedGame = await _gameService.GetGameToUpdateFromRequest(request);

        var updateGameCommand = new UpdateGameCommand() { Parameter = updatedGame };

        await _commandExecutor.ExecuteCommand(updateGameCommand);

        var response = new UpdateGameResponse() { Data = request };

        return response;
    }
}
