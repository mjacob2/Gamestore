using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Orders;
public class AddOrderItemCommand : CommandBase<OrderItem, OrderItem>
{
    public override async Task<OrderItem> Execute(GamestoreDbContext context)
    {
        await context.OrderItems.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
