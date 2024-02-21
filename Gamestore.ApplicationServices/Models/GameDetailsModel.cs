namespace Gamestore.ApplicationServices.Models;
public class GameDetailsModel
{
    public string GameAlias { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public List<GenreListingModel> Genres { get; set; } = new();

    public List<CommentListingModel> Comments { get; set; } = new();

    public int PublisherId { get; set; }

    public string Publisher { get; set; } = string.Empty;

    public List<PlatformListingModel> Platforms { get; set; } = new();

    public decimal Price { get; set; }

    public int UnitInStock { get; set; }

    public bool Discontinued { get; set; }
}
