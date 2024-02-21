using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Genres;

public class GetGenreByIdQuery : QueryBase<Genre?>
{
    public int GenreId { get; set; }

    public override async Task<Genre?> Execute(GamestoreDbContext context)
    {
        return await context.Genres
            .Include(x => x.SubGenres)
            .SingleOrDefaultAsync(x => x.Id == GenreId);
    }
}
