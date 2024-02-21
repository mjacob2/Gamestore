using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class GetOrdersHistoryRequest : IRequest<GetOrdersHistoryResponse>
{
    public string CustomerId { get; set; } = "DefaultClientId";

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
