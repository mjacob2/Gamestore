using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Publishers;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Publishers;
public class AddPublisherRequest : IRequest<AddPublisherResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string HomePage { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
}
