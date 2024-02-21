using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Queries.Shippers;
public class GetShipperByIdQuery : QueryBase<Shipper>
{
    public required string ShipperId { get; set; }

    public override async Task<Shipper> Execute(GamestoreDbContext context)
    {
        return await context.Shippers.FindAsync(ShipperId);
    }
}
