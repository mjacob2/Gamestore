using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class PayOrderByIBoxRequest : IRequest<PayOrderByIBoxResponse>
{
    public string CustomerId { get; set; } = "DefaultClientId";
}
