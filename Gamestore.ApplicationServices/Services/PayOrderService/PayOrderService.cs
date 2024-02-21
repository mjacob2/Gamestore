using Gamestore.ApplicationServices.Services.BankPaymentMethod;
using Gamestore.ApplicationServices.Services.RDPaymentService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Orders;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Queries.Orders;
using static Gamestore.ApplicationServices.Services.RDPaymentService.IRdPaymentApiConnector;

namespace Gamestore.ApplicationServices.Services.PayOrderService;
public class PayOrderService : IPayOrderService
{
    private const string MessageOnPaymentSuccess = "Order successfully paid!";
    private readonly IQueryExecutor _queryExecutor;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IRdPaymentApiConnector _rdPayment;
    private readonly IBankPaymentMethod _bankPayment;

    public PayOrderService(IBankPaymentMethod bankPayment, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor, IRdPaymentApiConnector rdPayment)
    {
        _bankPayment = bankPayment;
        _queryExecutor = queryExecutor;
        _commandExecutor = commandExecutor;
        SuccessPaymentMessage = MessageOnPaymentSuccess;
        _rdPayment = rdPayment;
    }

    public string SuccessPaymentMessage { get; }

    public async Task<bool> PayByIBox(decimal orderTotalPrice)
    {
        var iboxPaymentRequest = new IboxPaymentRequest()
        {
            TransactionAmount = orderTotalPrice,
            AccountNumber = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            InvoiceNumber = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        };

        return await _rdPayment.IBoxPaidWithSuccess(iboxPaymentRequest);
    }

    public async Task<bool> PayByVisa(decimal orderTotalPrice)
    {
        var visaPaymentRequest = new VisaPaymentRequest()
        {
            TransactionAmount = orderTotalPrice,
            CardHolderName = "Adam",
            CardNumber = "4654567898765434",
            ExpirationMonth = 12,
            ExpirationYear = 2024,
            Cvv = 999,
        };

        return await _rdPayment.VisaPaidWithSuccess(visaPaymentRequest);
    }

    public Stream PayByBank(Order order)
    {
        return _bankPayment.GenerateInvoice(order);
    }

    public async Task<Order> GetCurrentOrder(string customerId)
    {
        var query = new GetCurrentOrderByCustomerIdQuery() { CustomerId = customerId };
        var currentOrder = await _queryExecutor.ExecuteQuery(query);
        return currentOrder;
    }

    public async Task UpdateCartAsPaid(Order cart)
    {
        cart.Status = Order.OrderStatus.Paid;
        cart.PaidDate = DateTime.Now;

        var updateOrderCommand = new UpdateOrderCommand()
        {
            Parameter = cart,
        };

        await _commandExecutor.ExecuteCommand(updateOrderCommand);
    }

    public decimal ApplyDiscount(decimal totalPrice, decimal discountInPercent)
    {
        return totalPrice * (1 - discountInPercent);
    }
}
