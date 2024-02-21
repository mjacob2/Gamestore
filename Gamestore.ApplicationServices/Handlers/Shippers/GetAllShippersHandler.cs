using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.ApplicationServices.Responses.Shippers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Mongo;
using Gamestore.DataAccess.Mongo.Queries.Shippers;
using Gamestore.DataAccess.Queries.Shippers;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Shippers;
public class GetAllShippersHandler : IRequestHandler<GetAllShippersRequest, GetAllShippersResponse>
{
    private readonly IMongoQueryExecutor _mongoExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public GetAllShippersHandler(IMongoQueryExecutor mongoQueryMongoExecutor, IQueryExecutor queryExecutor)
    {
        _mongoExecutor = mongoQueryMongoExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetAllShippersResponse> Handle(GetAllShippersRequest request, CancellationToken cancellationToken)
    {
        var mongoQuery = new GetAllShippersFromMongoQuery();
        var shippersFromMongo = await _mongoExecutor.ExecuteQuery(mongoQuery);

        var query = new GetAllShippersQuery();
        var shippersFromSql = await _queryExecutor.ExecuteQuery(query);

        var shippers = Map(shippersFromSql, shippersFromMongo);
        var response = new GetAllShippersResponse()
        {
            Data = shippers,
        };

        return response;
    }

    private static List<ShipperListingModel> Map(List<Shipper> sqlShippers, List<DataAccess.Mongo.Entities.Shipper> mongoShippers)
    {
        var list = new List<ShipperListingModel>();

        foreach (var sqlOrder in sqlShippers)
        {
            var order = new ShipperListingModel()
            {
                CompanyName = sqlOrder.CompanyName,
                Phone = sqlOrder.Phone,
                ShipperId = sqlOrder.ShipperId.ToString(),
            };

            if (list.All(o => o.ShipperId != order.ShipperId))
            {
                list.Add(order);
            }
        }

        foreach (var mongoOrder in mongoShippers)
        {
            var order = new ShipperListingModel()
            {
                CompanyName = mongoOrder.CompanyName,
                Phone = mongoOrder.Phone,
                ShipperId = mongoOrder.Id,
            };

            if (list.All(o => o.ShipperId != order.ShipperId))
            {
                list.Add(order);
            }
        }

        return list;
    }
}
