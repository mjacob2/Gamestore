using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Games;

public class AddGameRequest : IRequest<AddGameResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(100)]
    public string GameAlias { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, 500, ErrorMessage = "{0} must be 0 or no more than 500")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, double.PositiveInfinity, ErrorMessage = "{0} must be 0 or more.")]
    public int UnitInStock { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public bool Discontinued { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public List<int> GenresIds { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public List<int> PlatformsIds { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(1, double.PositiveInfinity, ErrorMessage = "{0} must be 1 or more.")]
    public int PublisherId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public DateTime PublishDate { get; set; }
}
