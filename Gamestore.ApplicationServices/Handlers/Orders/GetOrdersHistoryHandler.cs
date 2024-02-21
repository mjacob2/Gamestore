using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Mongo;
using Gamestore.DataAccess.Queries.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
internal class GetOrdersHistoryHandler : IRequestHandler<GetOrdersHistoryRequest, GetOrdersHistoryResponse>
{
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMongoQueryExecutor _mongoQueryExecutor;

    public GetOrdersHistoryHandler(IQueryExecutor queryExecutor, IMongoQueryExecutor mongoQueryExecutor)
    {
        _queryExecutor = queryExecutor;
        _mongoQueryExecutor = mongoQueryExecutor;
    }

    public async Task<GetOrdersHistoryResponse> Handle(GetOrdersHistoryRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllOrdersQuery()
        {
            CustomerId = request.CustomerId,
            EndDate = request.EndDate,
            StartDate = request.StartDate,
        };
        var ordersFromSqlDatabase = await _queryExecutor.ExecuteQuery(query);

        var mongoQuery = new DataAccess.Mongo.Queries.Orders.GetAllOrdersQuery()
        {
            CustomerId = request.CustomerId,
            EndDate = request.EndDate,
            StartDate = request.StartDate,
        };
        var ordersFromMongoDatabase = await _mongoQueryExecutor.ExecuteQuery(mongoQuery);

        var orders = Map(ordersFromSqlDatabase, ordersFromMongoDatabase);

        var response = new GetOrdersHistoryResponse()
        {
            Data = orders,
        };

        return response;
    }

    private static List<OrderHistoryListingModel> Map(List<Order> sqlOrders, List<DataAccess.Mongo.Entities.Order> mongoOrders)
    {
        var list = new List<OrderHistoryListingModel>();

        foreach (var sqlOrder in sqlOrders)
        {
            var order = new OrderHistoryListingModel()
            {
                CustomerId = sqlOrder.CustomerId,
                OrderDate = sqlOrder.OrderDate,
                Id = sqlOrder.Id,
            };

            if (list.All(o => o.Id != order.Id))
            {
                list.Add(order);
            }
        }

        foreach (var mongoOrder in mongoOrders)
        {
            var order = new OrderHistoryListingModel()
            {
                CustomerId = mongoOrder.CustomerId,
                OrderDate = mongoOrder.OrderDate,
                Id = mongoOrder.OrderId,
            };

            if (list.All(o => o.Id != order.Id))
            {
                list.Add(order);
            }
        }

        return list;
    }
}