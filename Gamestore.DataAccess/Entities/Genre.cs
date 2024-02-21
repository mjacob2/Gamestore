using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public List<Genre> SubGenres { get; set; } = new();

    public int? ParentGenreId { get; set; }

    public Genre? ParentGenre { get; set; }

    public List<Game> Games { get; set; } = new();
}
