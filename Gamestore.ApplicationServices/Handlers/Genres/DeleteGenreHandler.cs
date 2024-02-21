using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.ApplicationServices.Responses.Genres;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Genres;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Genres;
public class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest, DeleteGenreResponse>
{
    private readonly ICommandExecutor _commandExecutor;

    public DeleteGenreHandler(ICommandExecutor commandExecutor)
    {
        _commandExecutor = commandExecutor;
    }

    public async Task<DeleteGenreResponse> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
    {
        var genreToDelete = new Genre()
        {
            Id = request.Id,
        };

        var command = new DeleteGenreCommand() { Parameter = genreToDelete };

        await _commandExecutor.ExecuteCommand(command);

        var response = new DeleteGenreResponse()
        {
            Data = request,
        };

        return response;
    }
}
