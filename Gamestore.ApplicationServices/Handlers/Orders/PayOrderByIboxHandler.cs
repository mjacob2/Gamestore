using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using Gamestore.ApplicationServices.Services.PayOrderService;
using Gamestore.DataAccess.Exceptions;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
public class PayOrderByIboxHandler : IRequestHandler<PayOrderByIBoxRequest, PayOrderByIBoxResponse>
{
    private const decimal Discount = 0.1M;
    private readonly IPayOrderService _orderService;

    public PayOrderByIboxHandler(IPayOrderService payOrderService)
    {
        _orderService = payOrderService;
    }

    public async Task<PayOrderByIBoxResponse> Handle(PayOrderByIBoxRequest request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderService.GetCurrentOrder(request.CustomerId);

        currentOrder.TotalPrice = _orderService.ApplyDiscount(currentOrder.TotalPrice, Discount);

        var iboxPaidWithSuccess = await _orderService.PayByIBox(currentOrder.TotalPrice);

        if (iboxPaidWithSuccess)
        {
            await _orderService.UpdateCartAsPaid(currentOrder);

            return new PayOrderByIBoxResponse()
            {
                Data = _orderService.SuccessPaymentMessage,
            };
        }
        else
        {
            throw new PaymentRejectedException("IBox");
        }
    }
}
