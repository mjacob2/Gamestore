using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class GetCurrentOrderRequest : IRequest<GetCurrentOrderResponse>
{
    public string CustomerId { get; set; } = "DefaultClientId";
}
