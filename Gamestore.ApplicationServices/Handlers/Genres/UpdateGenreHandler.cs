using AutoMapper;
using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.ApplicationServices.Responses.Genres;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Genres;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Genres;
public class UpdateGenreHandler : IRequestHandler<UpdateGenreRequest, UpdateGenreResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public UpdateGenreHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<UpdateGenreResponse> Handle(UpdateGenreRequest request, CancellationToken cancellationToken)
    {
        var genreToUpdate = _mapper.Map<Genre>(request);

        var command = new UpdateGenreCommand() { Parameter = genreToUpdate };

        await _commandExecutor.ExecuteCommand(command);

        var response = new UpdateGenreResponse()
        {
            Data = request,
        };

        return response;
    }
}
