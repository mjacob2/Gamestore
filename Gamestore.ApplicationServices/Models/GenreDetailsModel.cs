namespace Gamestore.ApplicationServices.Models;

public class GenreDetailsModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<string>? SubGenres { get; set; }
}
