using Gamestore.ApplicationServices.Responses.Shippers;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Shippers;
public class DeleteShipperByIdRequest : IRequest<DeleteShipperByIdResponse>
{
    public required string ShipperId { get; set; }
}
