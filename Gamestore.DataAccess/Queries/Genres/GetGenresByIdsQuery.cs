using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Genres;
public class GetGenresByIdsQuery : QueryBase<List<Genre>>
{
    public required List<int> GenresIds { get; set; }

    public override async Task<List<Genre>> Execute(GamestoreDbContext context)
    {
        return await context.Genres.Where(g => GenresIds.Contains(g.Id)).ToListAsync();
    }
}
