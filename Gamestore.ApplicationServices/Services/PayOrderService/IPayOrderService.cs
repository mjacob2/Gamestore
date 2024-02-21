using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Services.PayOrderService;
public interface IPayOrderService
{
    string SuccessPaymentMessage { get; }

    Task<Order> GetCurrentOrder(string customerId);

    Task UpdateCartAsPaid(Order cart);

    Stream PayByBank(Order order);

    Task<bool> PayByIBox(decimal orderTotalPrice);

    Task<bool> PayByVisa(decimal orderTotalPrice);

    decimal ApplyDiscount(decimal totalPrice, decimal discountInPercent);
}
