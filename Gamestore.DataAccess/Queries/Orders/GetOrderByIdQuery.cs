using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Orders;
public class GetOrderByIdQuery : QueryBase<Order?>
{
    public int OrderId { get; set; }

    public override async Task<Order?> Execute(GamestoreDbContext context)
    {
        return await context.Orders
            .Include(x => x.OrderItems)
            .SingleOrDefaultAsync(x => x.Id == OrderId);
    }
}
