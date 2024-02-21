using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Orders;
public class GetAllOrdersQuery : QueryBase<List<Order>>
{
    public required string CustomerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public override async Task<List<Order>> Execute(GamestoreDbContext context)
    {
        IQueryable<Order> query = context.Orders
            .Where(x => x.CustomerId == CustomerId)
            .OrderByDescending(x => x.Id);

        if (StartDate.HasValue)
        {
            query = query.Where(g => g.OrderDate >= StartDate.Value);
        }

        if (EndDate.HasValue)
        {
            query = query.Where(g => g.OrderDate <= EndDate.Value);
        }

        return await query.ToListAsync();
    }
}
