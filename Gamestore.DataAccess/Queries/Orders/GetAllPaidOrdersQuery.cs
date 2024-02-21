using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Orders;
public class GetAllPaidOrdersQuery : QueryBase<List<Order>>
{
    public required string CustomerId { get; set; }

    public override async Task<List<Order>> Execute(GamestoreDbContext context)
    {
        var orders = await context.Orders
    .Where(x => x.CustomerId == CustomerId & x.PaidDate != null)
    .OrderByDescending(x => x.Id)
    .Select(o => new Order
    {
        Id = o.Id,
        CustomerId = o.CustomerId,
        OrderDate = o.OrderDate,
        PaidDate = o.PaidDate,
        Sum = o.Sum,
        Discount = o.Discount,
        TotalPrice = o.TotalPrice,
        Status = o.Status,
        OrderItems = o.OrderItems.Select(oi => new OrderItem
        {
            Id = oi.Id,
            ProductId = oi.ProductId,
            Quantity = oi.Quantity,
            ProductPrice = oi.ProductPrice,
            ProductName = oi.ProductName,
            OrderId = oi.OrderId,
        }).ToList(),
    }).ToListAsync();

        return orders;
    }
}
