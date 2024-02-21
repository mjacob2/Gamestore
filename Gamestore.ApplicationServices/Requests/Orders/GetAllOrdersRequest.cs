using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class GetAllOrdersRequest : IRequest<GetAllOrdersResponse>
{
    public string CustomerId { get; set; } = "DefaultClientId";
}
