using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Publishers;
public class GetAllPublishersQuery : QueryBase<List<Publisher>>
{
    public override async Task<List<Publisher>> Execute(GamestoreDbContext context)
    {
        return await context.Publisher.ToListAsync();
    }
}
