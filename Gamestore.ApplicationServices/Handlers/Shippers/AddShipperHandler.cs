using AutoMapper;
using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.ApplicationServices.Responses.Shippers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Shippers;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Shippers;
public class AddShipperHandler : IRequestHandler<AddShipperRequest, AddShipperResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public AddShipperHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<AddShipperResponse> Handle(AddShipperRequest request, CancellationToken cancellationToken)
    {
        var shipperToAdd = _mapper.Map<Shipper>(request);
        shipperToAdd.ShipperId = Guid.NewGuid().ToString();

        var command = new AddShipperCommand() { Parameter = shipperToAdd };

        await _commandExecutor.ExecuteCommand(command);

        var response = new AddShipperResponse()
        {
            Data = request,
        };

        return response;
    }
}