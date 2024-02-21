using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Genres;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Genres;
public class DeleteGenreRequest : IRequest<DeleteGenreResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public int Id { get; set; }
}
