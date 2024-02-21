using System.Net;
using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.ApplicationServices.Responses.Genres;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : ApiControllerBase
{
    public GenresController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllGenresResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> GetAllGenres()
    {
        var request = new GetAllGenresRequest();
        return HandleRequest<GetAllGenresRequest, GetAllGenresResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetGenreByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{genreId}")]
    public Task<IActionResult> GetGenreById(int genreId)
    {
        var request = new GetGenreByIdRequest()
        {
            GenreId = genreId,
        };
        return HandleRequest<GetGenreByIdRequest, GetGenreByIdResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddGenreResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("new")]
    public Task<IActionResult> AddGenre(AddGenreRequest request)
    {
        return HandleRequest<AddGenreRequest, AddGenreResponse>(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateGenreResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("update")]
    public Task<IActionResult> UpdateGenre([FromBody] UpdateGenreRequest request)
    {
        return HandleRequest<UpdateGenreRequest, UpdateGenreResponse>(request);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteGenreResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("remove")]
    public Task<IActionResult> DeleteGenre([FromBody] DeleteGenreRequest request)
    {
        return HandleRequest<DeleteGenreRequest, DeleteGenreResponse>(request);
    }
}
