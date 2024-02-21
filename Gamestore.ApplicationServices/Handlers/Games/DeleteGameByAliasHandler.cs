using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;

public class DeleteGameByAliasHandler : IRequestHandler<DeleteGameRequest, DeleteGameResponse>
{
    private readonly ICommandExecutor _commandExecutor;

    public DeleteGameByAliasHandler(ICommandExecutor commandExecutor)
    {
        _commandExecutor = commandExecutor;
    }

    public async Task<DeleteGameResponse> Handle(DeleteGameRequest request, CancellationToken cancellationToken)
    {
        var gameToDelete = new Game()
        {
            GameAlias = request.GameAlias,
        };

        var command = new DeleteGameCommand() { Parameter = gameToDelete };

        await _commandExecutor.ExecuteCommand(command);

        var response = new DeleteGameResponse()
        {
            Data = request,
        };

        return response;
    }
}
