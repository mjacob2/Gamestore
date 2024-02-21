using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;
public class Publisher
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string CompanyName { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(100)]
    public string HomePage { get; set; } = string.Empty;

    public List<Game> Games { get; set; } = new List<Game>();
}
