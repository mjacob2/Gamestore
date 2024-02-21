namespace Gamestore.ApplicationServices.Services.GameAliasService;

public interface IGameAliasService
{
    string GenerateAlias(
        string nameFromRequest);

    string GenerateAliasFromName(string name);
}
