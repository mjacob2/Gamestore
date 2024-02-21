using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Commands.Shippers;
public class UpdateShipperCommand : CommandBase<Shipper, Shipper>
{
    public override async Task<Shipper> Execute(GamestoreDbContext context)
    {
        var existingShipper = await context.Shippers
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.ShipperId == Parameter.ShipperId);

        if (existingShipper is null)
        {
            context.Shippers.Add(Parameter);
        }
        else
        {
            context.Shippers.Update(Parameter);
        }

        await context.SaveChangesAsync();
        return Parameter;
    }
}
