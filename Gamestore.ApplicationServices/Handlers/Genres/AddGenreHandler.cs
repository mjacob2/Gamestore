using AutoMapper;
using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.ApplicationServices.Responses.Genres;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Genres;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Genres;
public class AddGenreHandler : IRequestHandler<AddGenreRequest, AddGenreResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public AddGenreHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<AddGenreResponse> Handle(AddGenreRequest request, CancellationToken cancellationToken)
    {
        var genreToAdd = _mapper.Map<Genre>(request);

        var addGenreCommand = new AddGenreCommand() { Parameter = genreToAdd };

        await _commandExecutor.ExecuteCommand(addGenreCommand);

        var response = new AddGenreResponse()
        {
            Data = request,
        };

        return response;
    }
}
