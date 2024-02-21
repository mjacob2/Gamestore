using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Shippers;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Shippers;
public class AddShipperRequest : IRequest<AddShipperResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(50)]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(20)]
    public string Phone { get; set; }
}
