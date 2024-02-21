using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Games;
using Gamestore.DataAccess.Queries.Games;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Games;

public class GetGameByAliasHandler : IRequestHandler<GetGameByAliasRequest, GetGameByAliasResponse>
{
    private readonly IQueryExecutor _executor;
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public GetGameByAliasHandler(IQueryExecutor executor, IMapper mapper, ICommandExecutor commandExecutor)
    {
        _executor = executor;
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<GetGameByAliasResponse> Handle(GetGameByAliasRequest request, CancellationToken cancellationToken)
    {
        var query = new GetGameByAliasQuery() { GameAlias = request.GameAlias };

        var gameFromDatabase = await _executor.ExecuteQuery(query);

        gameFromDatabase.ViewCount += 1;

        var updateGameWithViewCount = new UpdateGameCommand() { Parameter = gameFromDatabase };

        await _commandExecutor.ExecuteCommand(updateGameWithViewCount);

        var gameMappedToModel = _mapper.Map<GameDetailsModel>(gameFromDatabase);

        var response = new GetGameByAliasResponse() { Data = gameMappedToModel };

        return response;
    }
}
