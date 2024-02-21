using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Platforms;

public class UpdatePlatformCommand : CommandBase<Platform, Platform>
{
    public override async Task<Platform> Execute(GamestoreDbContext context)
    {
        context.Platforms.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
