using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Games;

public class GetAllGamesQuery : QueryBase<List<Game>>
{
    private static readonly int DefaultPageIndex;
    private static readonly int DefaultPagesize = 10;

    public enum SortOption
    {
        None,
        MostPopular,
        MostCommented,
        PriceAscending,
        PriceDescending,
        CreationDate,
    }

    public string? FilterName { get; set; }

    public List<string>? Publishers { get; set; }

    public List<PlatformType>? Platform { get; set; }

    public List<int>? Genre { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public SortOption? SortBy { get; set; } = SortOption.None;

    public int? PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalCount { get; set; }

    public override async Task<List<Game>> Execute(GamestoreDbContext context)
    {
        IQueryable<Game> query = context.Games
            .Include(g => g.Genres)
            .Include(g => g.Publisher)
            .Include(g => g.Platforms);

        if (!string.IsNullOrWhiteSpace(FilterName))
        {
            query = query.Where(g => g.Name.StartsWith(FilterName));
        }

        if (Publishers != null && Publishers.Count > 0)
        {
            query = query.Where(g => Publishers.Contains(g.Publisher.CompanyName));
        }

        if (Platform != null && Platform.Count > 0)
        {
            query = query.Where(g => g.Platforms.Any(p => Platform.Contains(p.Type)));
        }

        if (Genre != null && Genre.Count > 0)
        {
            query = query.Where(g => g.Genres.Any(g => Genre.Contains(g.Id)));
        }

        if (MinPrice.HasValue)
        {
            query = query.Where(g => g.Price >= MinPrice.Value);
        }

        if (MaxPrice.HasValue)
        {
            query = query.Where(g => g.Price <= MaxPrice.Value);
        }

        if (StartDate.HasValue)
        {
            query = query.Where(g => g.PublishDate >= StartDate.Value);
        }

        if (EndDate.HasValue)
        {
            query = query.Where(g => g.PublishDate <= EndDate.Value);
        }

        switch (SortBy)
        {
            case SortOption.MostPopular:
                query = query.OrderByDescending(g => g.ViewCount);
                break;
            case SortOption.MostCommented:
                query = query.OrderByDescending(g => g.Comments.Count);
                break;
            case SortOption.PriceAscending:
                query = query.OrderBy(g => g.Price);
                break;
            case SortOption.PriceDescending:
                query = query.OrderByDescending(g => g.Price);
                break;
            case SortOption.CreationDate:
                query = query.OrderByDescending(g => g.CreationDate);
                break;

            case SortOption.None:
            default:
                break;
        }

        TotalCount = await query.CountAsync();

        query = query.Skip(PageIndex.GetValueOrDefault(DefaultPageIndex) * PageSize)
            .Take(PageSize);

        return await query.ToListAsync();
    }
}
