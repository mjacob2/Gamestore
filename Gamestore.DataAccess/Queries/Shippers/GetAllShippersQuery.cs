using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Shippers;
public class GetAllShippersQuery : QueryBase<List<Shipper>>
{
    public override async Task<List<Shipper>> Execute(GamestoreDbContext context)
    {
        return await context.Shippers.ToListAsync();
    }
}
