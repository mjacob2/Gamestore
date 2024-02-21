using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Genres;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Genres;
public class GetGenreByIdRequest : IRequest<GetGenreByIdResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public int GenreId { get; set; }
}
