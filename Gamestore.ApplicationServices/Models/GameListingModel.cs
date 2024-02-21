namespace Gamestore.ApplicationServices.Models;

public class GameListingModel
{
    public string GameAlias { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public List<string> GenresNames { get; set; } = new();

    public string Publisher { get; set; } = string.Empty;

    public List<string> PlatformsNames { get; set; } = new();

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }

    public DateTime PublishDate { get; set; }

    public DateTime CreationDate { get; set; }

    public int ViewCount { get; set; }
}
