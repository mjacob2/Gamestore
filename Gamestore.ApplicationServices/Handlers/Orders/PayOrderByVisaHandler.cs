using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using Gamestore.ApplicationServices.Services.PayOrderService;
using Gamestore.DataAccess.Exceptions;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
public class PayOrderByVisaHandler : IRequestHandler<PayOrderByVisaRequest, PayOrderByVisaResponse>
{
    private const decimal Discount = 0.1M;
    private readonly IPayOrderService _orderService;

    public PayOrderByVisaHandler(IPayOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<PayOrderByVisaResponse> Handle(PayOrderByVisaRequest request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderService.GetCurrentOrder(request.CustomerId);

        currentOrder.TotalPrice = _orderService.ApplyDiscount(currentOrder.TotalPrice, Discount);

        var visaPaidWithSuccess = await _orderService.PayByVisa(currentOrder.TotalPrice);

        if (visaPaidWithSuccess)
        {
            await _orderService.UpdateCartAsPaid(currentOrder);

            return new PayOrderByVisaResponse()
            {
                Data = _orderService.SuccessPaymentMessage,
            };
        }
        else
        {
            throw new PaymentRejectedException("Visa");
        }
    }
}
