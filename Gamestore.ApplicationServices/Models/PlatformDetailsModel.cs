using Gamestore.DataAccess.Entities;

namespace Gamestore.ApplicationServices.Models;
public class PlatformDetailsModel
{
    public int Id { get; set; }

    public PlatformType Type { get; set; }

    public string Description { get; set; } = string.Empty;

    public List<Game>? Games { get; set; } = new List<Game>();
}
