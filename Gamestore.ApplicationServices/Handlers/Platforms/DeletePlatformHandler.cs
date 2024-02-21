using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.ApplicationServices.Responses.Platofrms;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Platforms;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Platforms;
public class DeletePlatformHandler : IRequestHandler<DeletePlatformRequest, DeletePlatformResponse>
{
    private readonly ICommandExecutor _commandExecutor;

    public DeletePlatformHandler(ICommandExecutor commandExecutor)
    {
        _commandExecutor = commandExecutor;
    }

    public async Task<DeletePlatformResponse> Handle(DeletePlatformRequest request, CancellationToken cancellationToken)
    {
        var platformToDelete = new Platform()
        {
            Id = request.PlatformId,
        };

        var command = new DeletePlatformCommand() { Parameter = platformToDelete };

        await _commandExecutor.ExecuteCommand(command);

        var response = new DeletePlatformResponse()
        {
            Data = request.PlatformId,
        };

        return response;
    }
}
