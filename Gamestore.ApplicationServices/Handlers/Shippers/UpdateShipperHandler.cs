using AutoMapper;
using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.ApplicationServices.Responses.Shippers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Shippers;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Shippers;
public class UpdateShipperHandler : IRequestHandler<UpdateShipperRequest, UpdateShipperResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public UpdateShipperHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<UpdateShipperResponse> Handle(UpdateShipperRequest request, CancellationToken cancellationToken)
    {
        var shipperToUpdate = _mapper.Map<Shipper>(request);
        var updateCommand = new UpdateShipperCommand() { Parameter = shipperToUpdate };
        await _commandExecutor.ExecuteCommand(updateCommand);

        return new UpdateShipperResponse() { Data = request };
    }
}
