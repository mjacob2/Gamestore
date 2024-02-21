using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Orders;
public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public int OrderId { get; set; }
}
