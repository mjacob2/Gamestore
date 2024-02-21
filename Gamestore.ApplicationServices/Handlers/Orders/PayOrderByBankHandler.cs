using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Services.PayOrderService;
using Gamestore.DataAccess.Exceptions;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
public class PayOrderByBankHandler : IRequestHandler<PayOrderByBankRequest, Stream>
{
    private readonly IPayOrderService _orderService;

    public PayOrderByBankHandler(IPayOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Stream> Handle(PayOrderByBankRequest request, CancellationToken cancellationToken)
    {
        var currentOrder = await _orderService.GetCurrentOrder(request.CustomerId);

        var invoice = _orderService.PayByBank(currentOrder) ?? throw new PaymentRejectedException("Bank");

        await _orderService.UpdateCartAsPaid(currentOrder);

        return invoice;
    }
}