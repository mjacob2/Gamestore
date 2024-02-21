using System.Net;
using Gamestore.ApplicationServices.Requests.Users;
using Gamestore.ApplicationServices.Responses.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ApiControllerBase
{
    public UsersController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType(typeof(BanUserFromCommentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("ban")]
    public Task<IActionResult> BanUserFromComment([FromBody] BanUserFromCommentRequest request)
    {
        return HandleRequest<BanUserFromCommentRequest, BanUserFromCommentResponse>(request);
    }
}
