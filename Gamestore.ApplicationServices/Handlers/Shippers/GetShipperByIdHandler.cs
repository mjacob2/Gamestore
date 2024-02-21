using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.ApplicationServices.Responses.Shippers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Exceptions;
using Gamestore.DataAccess.Mongo;
using Gamestore.DataAccess.Mongo.Queries.Shippers;
using Gamestore.DataAccess.Queries.Shippers;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Shippers;
public class GetShipperByIdHandler : IRequestHandler<GetShipperByIdRequest, GetShipperByIdResponse>
{
    private readonly IMongoQueryExecutor _executor;
    private readonly IQueryExecutor _queryExecutor;

    public GetShipperByIdHandler(IMongoQueryExecutor mongoQueryExecutor, IQueryExecutor queryExecutor)
    {
        _executor = mongoQueryExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetShipperByIdResponse> Handle(GetShipperByIdRequest request, CancellationToken cancellationToken)
    {
        var response = new GetShipperByIdResponse();

        try
        {
            var shipperFromSql = await _queryExecutor.ExecuteQuery(new GetShipperByIdQuery() { ShipperId = request.ShipperId });
            response.Data = new ShipperListingModel(shipperFromSql);
        }
        catch (NotFoundException)
        {
            var shipperFromMongo = await _executor.ExecuteQuery(new GetShipperByIdMongoQuery() { ShipperId = request.ShipperId });
            response.Data = new ShipperListingModel(shipperFromMongo);
        }

        return response;
    }
}