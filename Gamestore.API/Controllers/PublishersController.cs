using System.Net;
using Gamestore.ApplicationServices.Requests.Publishers;
using Gamestore.ApplicationServices.Responses.Publishers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PublishersController : ApiControllerBase
{
    public PublishersController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllPublishersResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> GetAllPublishers()
    {
        var request = new GetAllPublishersRequest();
        return HandleRequest<GetAllPublishersRequest, GetAllPublishersResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddPublisherResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("new")]
    public Task<IActionResult> AddPublisher(AddPublisherRequest request)
    {
        return HandleRequest<AddPublisherRequest, AddPublisherResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetPublisherByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{publisherId}")]
    public Task<IActionResult> GetPublisherById(int publisherId)
    {
        var request = new GetPublisherByIdRequest()
        {
            PublisherId = publisherId,
        };
        return HandleRequest<GetPublisherByIdRequest, GetPublisherByIdResponse>(request);
    }
}
