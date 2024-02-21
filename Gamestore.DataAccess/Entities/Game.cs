using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;

public class Game
{
    [Key]
    [MaxLength(100)]
    public string GameAlias { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public List<Genre> Genres { get; set; } = new();

    public int PlatformId { get; set; }

    public List<Platform> Platforms { get; set; } = new();

    public int PublisherId { get; set; }

    public Publisher Publisher { get; set; }

    public List<Comment> Comments { get; set; } = new();

    public int ViewCount { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime CreationDate { get; set; }
}
