using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class PayOrderByBankRequest : IRequest<Stream>
{
    public string CustomerId { get; set; } = "DefaultClientId";
}
