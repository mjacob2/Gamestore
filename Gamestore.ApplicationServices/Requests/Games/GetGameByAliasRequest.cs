using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Games;

public class GetGameByAliasRequest : IRequest<GetGameByAliasResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string GameAlias { get; set; }
}
