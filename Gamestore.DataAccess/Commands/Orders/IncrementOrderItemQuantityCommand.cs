using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Exceptions;

namespace Gamestore.DataAccess.Commands.Orders;
public class IncrementOrderItemQuantityCommand : CommandBase<OrderItem, OrderItem>
{
    private readonly string _errorMessageWhenNoItemsInStock = "All available items are already in the cart";

    public required int UnitsInStock { get; set; }

    public override async Task<OrderItem> Execute(GamestoreDbContext context)
    {
        Parameter.Quantity += 1;

        if (UnitsInStock < Parameter.Quantity)
        {
            throw new NoUnitsInStockException($"{_errorMessageWhenNoItemsInStock}");
        }

        context.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
