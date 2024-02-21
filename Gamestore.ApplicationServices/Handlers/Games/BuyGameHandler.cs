using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Orders;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Queries.Games;
using Gamestore.DataAccess.Queries.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;
public class BuyGameHandler : IRequestHandler<BuyGameRequest, BuyGameResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;

    public BuyGameHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<BuyGameResponse> Handle(BuyGameRequest request, CancellationToken cancellationToken)
    {
        var gameToBuy = await GetGameToBuy(request.GameAlias);

        var currentOrder = await GetCurrentOrder(request.CustomerId);

        var orderItemToAddOrUpdate = GetOrderItemForThisGame(currentOrder, request.GameAlias);

        if (orderItemToAddOrUpdate != null)
        {
            await IncremenItemOrder(orderItemToAddOrUpdate, gameToBuy.UnitInStock);
        }
        else
        {
            orderItemToAddOrUpdate = AddNewItemOrder(gameToBuy, currentOrder);
        }

        await RecalculateCurrentOrder(currentOrder);

        var orderItemToAddOrUpdateMappedToModel = _mapper.Map<OrderItemDetailsModel>(orderItemToAddOrUpdate);

        var response = new BuyGameResponse()
        {
            Data = orderItemToAddOrUpdateMappedToModel,
        };

        return response;
    }

    private async Task RecalculateCurrentOrder(Order currentOrder)
    {
        currentOrder.Sum = currentOrder.OrderItems.Sum(x => x.Quantity);
        currentOrder.TotalPrice = currentOrder.OrderItems.Sum(x => x.ProductPrice * x.Quantity);

        var updateOrderCommand = new UpdateOrderCommand() { Parameter = currentOrder };
        await _commandExecutor.ExecuteCommand(updateOrderCommand);
    }

    private static OrderItem AddNewItemOrder(Game gameToBuy, Order currentOrder)
    {
        var orderItemToAddOrUpdate = new OrderItem
        {
            OrderId = currentOrder.Id,
            ProductId = gameToBuy.GameAlias,
            ProductName = gameToBuy.Name,
            ProductPrice = gameToBuy.Price,
            Quantity = 1,
        };

        currentOrder.OrderItems.Add(orderItemToAddOrUpdate);
        return orderItemToAddOrUpdate;
    }

    private async Task<Game> GetGameToBuy(string gameAlias)
    {
        var gameToBuyQuery = new GetGameToBuyQuery() { GameAlias = gameAlias };
        return await _queryExecutor.ExecuteQuery(gameToBuyQuery);
    }

    private async Task<Order> GetCurrentOrder(string customerId)
    {
        var orderQuery = new GetCurrentOrderByCustomerIdQuery() { CustomerId = customerId };
        return await _queryExecutor.ExecuteQuery(orderQuery);
    }

    private static OrderItem? GetOrderItemForThisGame(Order order, string gameAlias)
    {
        return order.OrderItems.FirstOrDefault(x => x.ProductId.Equals(gameAlias));
    }

    private async Task IncremenItemOrder(OrderItem orderItemToAddOrUpdate, int unitsInStock)
    {
        var updateOrderItemCommand = new IncrementOrderItemQuantityCommand() { Parameter = orderItemToAddOrUpdate, UnitsInStock = unitsInStock };
        await _commandExecutor.ExecuteCommand(updateOrderItemCommand);
    }
}
