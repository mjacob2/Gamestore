using AutoMapper;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Services.GameAliasService;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Exceptions;
using Gamestore.DataAccess.Queries.Games;
using Gamestore.DataAccess.Queries.Genres;
using Gamestore.DataAccess.Queries.Platforms;

namespace Gamestore.ApplicationServices.Services.GameHandlerService;
public class GameHandlerService : IGameHandlerService
{
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;
    private readonly IGameAliasService _aliasService;

    public GameHandlerService(IQueryExecutor queryExecutor, IMapper mapper, IGameAliasService aliasService)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
        _aliasService = aliasService;
    }

    public async Task<Game> GetGameToAddFromRequest(AddGameRequest request)
    {
        if (string.IsNullOrEmpty(request.GameAlias))
        {
            request.GameAlias = _aliasService.GenerateAlias(request.Name);
        }

        if (await IsGameAliasAlreadyTaken(request.GameAlias))
        {
            throw new UniquePropertyException(nameof(request.GameAlias), request.GameAlias);
        }

        var gameToAdd = _mapper.Map<Game>(request);

        await AssignRelatedEntities(request.PlatformsIds, request.GenresIds, gameToAdd);

        return gameToAdd;
    }

    public async Task<Game> GetGameToUpdateFromRequest(UpdateGameRequest request)
    {
        var getGameToUpdateQuery = new GetGameByAliasQuery() { GameAlias = request.GameAlias };
        var gameFromDbToUpdate = await _queryExecutor.ExecuteQuery(getGameToUpdateQuery);
        var updatedGame = _mapper.Map(request, gameFromDbToUpdate);

        await AssignRelatedEntities(request.PlatformsIds, request.GenresIds, updatedGame);

        return updatedGame;
    }

    public async Task<bool> IsGameAliasAlreadyTaken(string gameAlias)
    {
        var getAllAliasesQuery = new GetAlreadyUsedAliasesQuery();
        var alreadyUsedAliases = await _queryExecutor.ExecuteQuery(getAllAliasesQuery);
        return alreadyUsedAliases.Contains(gameAlias);
    }

    private async Task AssignRelatedEntities(List<int> platformsIds, List<int> genresIds, Game game)
    {
        await AssignPlatformsToGame(platformsIds, game);
        await AssignGenresToGame(genresIds, game);
    }

    private async Task AssignPlatformsToGame(List<int> platformsIds, Game game)
    {
        var getRequestPlatformsQuery = new GetPlatformsByIdsQuery() { PlatformsIds = platformsIds };
        var requestPlatforms = await _queryExecutor.ExecuteQuery(getRequestPlatformsQuery);
        game.Platforms = requestPlatforms;
    }

    private async Task AssignGenresToGame(List<int> genresIds, Game game)
    {
        var getRequestGenresQuery = new GetGenresByIdsQuery() { GenresIds = genresIds };
        var requestGenres = await _queryExecutor.ExecuteQuery(getRequestGenresQuery);
        game.Genres = requestGenres;
    }
}
