using AutoMapper;
using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.ApplicationServices.Responses.Platofrms;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Platforms;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Platforms;
public class UpdatePlatformHandler : IRequestHandler<UpdatePlatformRequest, UpdatePlatformResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public UpdatePlatformHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<UpdatePlatformResponse> Handle(UpdatePlatformRequest request, CancellationToken cancellationToken)
    {
        var platformToUpdate = _mapper.Map<Platform>(request);

        var command = new UpdatePlatformCommand() { Parameter = platformToUpdate };

        await _commandExecutor.ExecuteCommand(command);

        var response = new UpdatePlatformResponse()
        {
            Data = request,
        };

        return response;
    }
}
