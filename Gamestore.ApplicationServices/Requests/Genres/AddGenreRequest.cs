using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Genres;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Genres;
public class AddGenreRequest : IRequest<AddGenreResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Range(0, double.PositiveInfinity, ErrorMessage = "{0} must be 0 or more.")]
    public int? ParentGenreId { get; set; }
}
