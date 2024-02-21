using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Publishers;
public class GetPublisherByIdQuery : QueryBase<Publisher?>
{
    public int PublisherId { get; set; }

    public override async Task<Publisher?> Execute(GamestoreDbContext context)
    {
        return await context.Publisher
            .SingleOrDefaultAsync(x => x.Id == PublisherId);
    }
}
