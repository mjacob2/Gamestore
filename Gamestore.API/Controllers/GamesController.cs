using System.Net;
using Gamestore.ApplicationServices.Requests.Games;
using Gamestore.ApplicationServices.Responses.Games;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ApiControllerBase
{
    public GamesController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllGamesResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> GetAllGamesAsync([FromQuery] GetAllGamesRequest request)
    {
        return HandleRequest<GetAllGamesRequest, GetAllGamesResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetGameByAliasResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{gameAlias}")]
    public Task<IActionResult> GetGameByAliasAsync(string gameAlias)
    {
        var request = new GetGameByAliasRequest { GameAlias = gameAlias };
        return HandleRequest<GetGameByAliasRequest, GetGameByAliasResponse>(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(BuyGameResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{gameAlias}/buy")]
    public Task<IActionResult> BuyGame(string gameAlias)
    {
        var request = new BuyGameRequest { GameAlias = gameAlias };
        return HandleRequest<BuyGameRequest, BuyGameResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddGameResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("new")]
    public Task<IActionResult> AddGame(AddGameRequest request)
    {
        return HandleRequest<AddGameRequest, AddGameResponse>(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateGameResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("update")]
    public Task<IActionResult> UpdateGame([FromBody] UpdateGameRequest request)
    {
        return HandleRequest<UpdateGameRequest, UpdateGameResponse>(request);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteGameResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("remove")]
    public Task<IActionResult> DeleteGameByAlias([FromBody] DeleteGameRequest request)
    {
        return HandleRequest<DeleteGameRequest, DeleteGameResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{alias}/download")]
    public async Task<IActionResult> DownloadGame(string alias)
    {
        var request = new DownloadGameRequest { GameAlias = alias };

        return await HandleDownloadGameRequest<DownloadGameRequest, Stream>(request);
    }
}
