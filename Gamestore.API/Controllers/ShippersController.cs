using System.Net;
using Gamestore.ApplicationServices.Requests.Shippers;
using Gamestore.ApplicationServices.Responses.Shippers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ShippersController : ApiControllerBase
{
    public ShippersController(IMediator mediator)
    : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllShippersResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> GetAllShippersAsync([FromQuery] GetAllShippersRequest request)
    {
        return HandleRequest<GetAllShippersRequest, GetAllShippersResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetShipperByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{shipperId}")]
    public Task<IActionResult> GetShipperById(string shipperId)
    {
        var request = new GetShipperByIdRequest()
        {
            ShipperId = shipperId,
        };
        return HandleRequest<GetShipperByIdRequest, GetShipperByIdResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddShipperResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> AddShipper([FromBody] AddShipperRequest request)
    {
        return HandleRequest<AddShipperRequest, AddShipperResponse>(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateShipperResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> UpdateShipper([FromBody] UpdateShipperRequest request)
    {
        return HandleRequest<UpdateShipperRequest, UpdateShipperResponse>(request);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeleteShipperByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{shipperId}")]
    public Task<IActionResult> AddShipper(string shipperId)
    {
        var request = new DeleteShipperByIdRequest()
        {
            ShipperId = shipperId,
        };
        return HandleRequest<DeleteShipperByIdRequest, DeleteShipperByIdResponse>(request);
    }
}
