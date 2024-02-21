using System.Net;
using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.ApplicationServices.Responses.Platofrms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformsController : ApiControllerBase
{
    public PlatformsController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllPlatformsResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> GetAllPlatforms()
    {
        var request = new GetAllPlatformsRequest();
        return HandleRequest<GetAllPlatformsRequest, GetAllPlatformsResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddPlatformResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("new")]
    public Task<IActionResult> AddPlatform(AddPlatformRequest request)
    {
        return HandleRequest<AddPlatformRequest, AddPlatformResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPlatformByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{platformId}")]
    public Task<IActionResult> GetPlatformById(int platformId)
    {
        var request = new GetPlatformByIdRequest()
        {
            PlatformId = platformId,
        };
        return HandleRequest<GetPlatformByIdRequest, GetPlatformByIdResponse>(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdatePlatformResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("update")]
    public Task<IActionResult> UpdatePlatform([FromBody] UpdatePlatformRequest request)
    {
        return HandleRequest<UpdatePlatformRequest, UpdatePlatformResponse>(request);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeletePlatformResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("remove")]
    public Task<IActionResult> DeletePlatofrm([FromBody] DeletePlatformRequest request)
    {
        return HandleRequest<DeletePlatformRequest, DeletePlatformResponse>(request);
    }
}
