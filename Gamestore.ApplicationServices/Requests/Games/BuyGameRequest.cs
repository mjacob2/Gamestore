using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Games;
public class BuyGameRequest : IRequest<BuyGameResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string GameAlias { get; set; }

    public string CustomerId { get; set; } = "DefaultClientId";
}
