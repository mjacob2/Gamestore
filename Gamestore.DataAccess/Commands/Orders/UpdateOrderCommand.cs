using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Orders;
public class UpdateOrderCommand : CommandBase<Order, Order>
{
    public override async Task<Order> Execute(GamestoreDbContext context)
    {
        context.Orders.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
