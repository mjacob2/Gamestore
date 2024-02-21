using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Platofrms;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Platforms;
public class DeletePlatformRequest : IRequest<DeletePlatformResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public int PlatformId { get; set; }
}
