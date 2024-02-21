using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Genres;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Genres;

public class UpdateGenreRequest : IRequest<UpdateGenreResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string Name { get; set; }

    public int? ParentGenreId { get; set; }
}