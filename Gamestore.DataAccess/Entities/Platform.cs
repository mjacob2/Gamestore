using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;

public enum PlatformType
{
    Mobile,
    Browser,
    Desktop,
    Console,
}

public class Platform
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public PlatformType Type { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public List<Game> Games { get; set; } = new();
}
