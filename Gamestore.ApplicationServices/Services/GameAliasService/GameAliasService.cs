using System.Text.RegularExpressions;
using Gamestore.ApplicationServices.Services.GameAliasService;

namespace Gamestore.ApplicationServices;

public partial class GameAliasService : IGameAliasService
{
    public string GenerateAlias(string nameFromRequest)
    {
        return GenerateAliasFromName(nameFromRequest);
    }

    public string GenerateAliasFromName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        name = name.Trim();
        name = name.Replace(" ", "-");
        Regex rgx = MyRegex();
        name = rgx.Replace(name.ToLowerInvariant(), string.Empty);

        return name;
    }

    [GeneratedRegex("[^a-z0-9-]")]
    private static partial Regex MyRegex();
}
