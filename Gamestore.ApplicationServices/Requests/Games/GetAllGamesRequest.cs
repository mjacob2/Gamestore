using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Queries.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Games;

public class GetAllGamesRequest : IRequest<GetAllGamesResponse>
{
    private static readonly int DefaultPageIndex;
    private static readonly int DefaultPagesize = 10;

    public GetAllGamesQuery.SortOption? SortBy { get; set; }

    public string? FilterName { get; set; }

    public List<string>? Publisher { get; set; }

    public List<PlatformType>? Platform { get; set; }

    public List<int>? Genre { get; set; }

    public int? MinPrice { get; set; }

    public int? MaxPrice { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? PageIndex { get; set; } = DefaultPageIndex;

    public int PageSize { get; set; } = DefaultPagesize;
}
