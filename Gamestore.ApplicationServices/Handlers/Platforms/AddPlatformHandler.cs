using AutoMapper;
using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.ApplicationServices.Responses.Platofrms;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Platforms;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Platforms;
public class AddPlatformHandler : IRequestHandler<AddPlatformRequest, AddPlatformResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public AddPlatformHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<AddPlatformResponse> Handle(AddPlatformRequest request, CancellationToken cancellationToken)
    {
        var platformToAdd = _mapper.Map<Platform>(request);

        var addPlatformCommand = new AddPlatformCommand() { Parameter = platformToAdd };

        await _commandExecutor.ExecuteCommand(addPlatformCommand);

        var response = new AddPlatformResponse()
        {
            Data = request,
        };

        return response;
    }
}
