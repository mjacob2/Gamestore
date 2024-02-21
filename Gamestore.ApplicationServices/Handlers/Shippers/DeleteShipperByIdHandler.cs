using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.ApplicationServices.Responses.Shippers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Shippers;
using Gamestore.DataAccess.Queries.Shippers;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Shippers;
public class DeleteShipperByIdHandler : IRequestHandler<DeleteShipperByIdRequest, DeleteShipperByIdResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public DeleteShipperByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<DeleteShipperByIdResponse> Handle(DeleteShipperByIdRequest request, CancellationToken cancellationToken)
    {
        var getShipperToDeleteQuery = new GetShipperByIdQuery() { ShipperId = request.ShipperId };
        var shipperToDelete = await _queryExecutor.ExecuteQuery(getShipperToDeleteQuery);
        var commandDelete = new DeleteShipperByIdCommand() { Parameter = shipperToDelete };
        await _commandExecutor.ExecuteCommand(commandDelete);
        return new DeleteShipperByIdResponse();
    }
}