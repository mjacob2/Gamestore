using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class PayOrderByVisaRequest : IRequest<PayOrderByVisaResponse>
{
    public string CustomerId { get; set; } = "DefaultClientId";
}
