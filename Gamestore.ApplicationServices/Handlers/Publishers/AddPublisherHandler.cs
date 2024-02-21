using AutoMapper;
using Gamestore.ApplicationServices.Requests.Publishers;
using Gamestore.ApplicationServices.Responses.Publishers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Publishers;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Publishers;
public class AddPublisherHandler : IRequestHandler<AddPublisherRequest, AddPublisherResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public AddPublisherHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<AddPublisherResponse> Handle(AddPublisherRequest request, CancellationToken cancellationToken)
    {
        var publisherToAdd = _mapper.Map<Publisher>(request);

        var addPublisherCommand = new AddPublisherCommand() { Parameter = publisherToAdd };

        await _commandExecutor.ExecuteCommand(addPublisherCommand);

        var response = new AddPublisherResponse()
        {
            Data = request,
        };

        return response;
    }
}
