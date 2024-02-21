using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Publishers;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Publishers;
public class GetPublisherByIdRequest : IRequest<GetPublisherByIdResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public int PublisherId { get; set; }
}
