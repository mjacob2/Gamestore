using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Games;
public class DownloadGameRequest : IRequest<Stream>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string GameAlias { get; set; }
}
