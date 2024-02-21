using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Publishers;
public class AddPublisherCommand : CommandBase<Publisher, Publisher>
{
    public override async Task<Publisher> Execute(GamestoreDbContext context)
    {
        await context.Publisher.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}