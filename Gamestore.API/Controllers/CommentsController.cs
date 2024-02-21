using System.Net;
using Gamestore.ApplicationServices.Requests.Comments;
using Gamestore.ApplicationServices.Responses.Comments;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CommentsController : ApiControllerBase
{
    public CommentsController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddCommentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> AddComment([FromBody] AddCommentRequest request)
    {
        if (Request.Cookies.TryGetValue("guest-user-id", out var userid))
        {
            request.UserId = userid;
        }
        else
        {
            userid = Guid.NewGuid().ToString();
            Response.Cookies.Append("guest-user-id", userid, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                Expires = DateTime.UtcNow.AddYears(1),
            });
            request.UserId = userid;
        }

        return HandleRequest<AddCommentRequest, AddCommentResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BanCommentResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("ban")]
    public Task<IActionResult> BanComment([FromBody] BanCommentRequest request)
    {
        return HandleRequest<BanCommentRequest, BanCommentResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetCommentsByGameAliasResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{gameAlias}")]
    public Task<IActionResult> GetCommentsByGameAlias(string gameAlias)
    {
        var request = new GetCommentsByGameAliasRequest() { GameAlias = gameAlias };

        if (Request.Cookies.TryGetValue("guest-user-id", out var userid))
        {
            request.UserId = userid;
        }

        return HandleRequest<GetCommentsByGameAliasRequest, GetCommentsByGameAliasResponse>(request);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteCommentByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{commentId}")]
    public Task<IActionResult> DeleteCommentById(int commentId)
    {
        var request = new DeleteCommentByIdRequest() { CommentId = commentId };

        if (Request.Cookies.TryGetValue("guest-user-id", out var userid))
        {
            request.UserId = userid;
        }

        return HandleRequest<DeleteCommentByIdRequest, DeleteCommentByIdResponse>(request);
    }
}
