using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Shippers;
public class AddShipperCommand : CommandBase<Shipper, Shipper>
{
    public override async Task<Shipper> Execute(GamestoreDbContext context)
    {
        await context.Shippers.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
