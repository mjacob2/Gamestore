using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Shippers;
public class DeleteShipperByIdCommand : CommandBase<Shipper, Shipper>
{
    public override async Task<Shipper> Execute(GamestoreDbContext context)
    {
        context.Shippers.Remove(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
