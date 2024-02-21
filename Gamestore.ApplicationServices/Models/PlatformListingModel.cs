namespace Gamestore.ApplicationServices.Models;
public class PlatformListingModel
{
    public int Id { get; set; }

    public string Type { get; set; }

    public List<string>? Games { get; set; }
}
