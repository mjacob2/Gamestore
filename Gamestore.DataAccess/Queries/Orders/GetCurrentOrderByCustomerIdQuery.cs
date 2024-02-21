﻿using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Orders;
public class GetCurrentOrderByCustomerIdQuery : QueryBase<Order>
{
    public required string CustomerId { get; set; }

    public override async Task<Order> Execute(GamestoreDbContext context)
    {
        var currentOrder = await context.Orders
    .Where(x => x.CustomerId == CustomerId && x.PaidDate == null && x.Status == Order.OrderStatus.Open)
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
    })
    .SingleOrDefaultAsync();

        if (currentOrder == null)
        {
            currentOrder = new Order()
            {
                OrderDate = DateTime.Now,
                CustomerId = CustomerId,
                OrderItems = new List<OrderItem>(),
                Discount = 0,
                Sum = 0,
                TotalPrice = 0,
                Status = Order.OrderStatus.Open,
            };

            await context.AddAsync(currentOrder);
            await context.SaveChangesAsync();
        }

        return currentOrder;
    }
}
