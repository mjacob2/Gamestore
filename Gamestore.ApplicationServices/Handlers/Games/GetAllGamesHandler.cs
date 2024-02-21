using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Exceptions;
using Gamestore.DataAccess.Queries.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;

public class GetAllGamesHandler : IRequestHandler<GetAllGamesRequest, GetAllGamesResponse>
{
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;

    public GetAllGamesHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetAllGamesResponse> Handle(GetAllGamesRequest request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.FilterName) && request.FilterName.Length < 3)
        {
            throw new BadRequestException("Game Name filter must be 3 characters long if provided.");
        }

        var query = new GetAllGamesQuery()
        {
            SortBy = request.SortBy,
            FilterName = request.FilterName,
            Publishers = request.Publisher,
            Genre = request.Genre,
            Platform = request.Platform,
            MinPrice = request.MinPrice,
            MaxPrice = request.MaxPrice,
            EndDate = request.EndDate,
            StartDate = request.StartDate,

            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
        };

        var gamesFromDatabase = await _queryExecutor.ExecuteQuery(query);
        var gamesMappedToModel = _mapper.Map<List<GameListingModel>>(gamesFromDatabase);
        var response = new GetAllGamesResponse()
        {
            Data = gamesMappedToModel,
            TotalCount = query.TotalCount,
        };
        return response;
    }
}
