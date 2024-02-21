using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Genres;

public class GetAllGenresQuery : QueryBase<List<Genre>>
{
    public override async Task<List<Genre>> Execute(GamestoreDbContext context)
    {
        return await context.Genres.ToListAsync();
    }
}
