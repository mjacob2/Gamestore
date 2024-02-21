using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Platforms;

public class AddPlatformCommand : CommandBase<Platform, Platform>
{
    public override async Task<Platform> Execute(GamestoreDbContext context)
    {
        await context.Platforms.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
