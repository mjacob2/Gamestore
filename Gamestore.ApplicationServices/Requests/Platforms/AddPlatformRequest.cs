using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Platofrms;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Platforms;
public class AddPlatformRequest : IRequest<AddPlatformResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public PlatformType Type { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
}
