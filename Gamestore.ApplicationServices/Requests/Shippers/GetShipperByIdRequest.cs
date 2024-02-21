using Gamestore.ApplicationServices.Responses.Shippers;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Shippers;
public class GetShipperByIdRequest : IRequest<GetShipperByIdResponse>
{
    public required string ShipperId { get; set; }
}
