using System.Net;
using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ApiControllerBase
{
    public OrdersController(IMediator mediator)
    : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetCurrentOrderResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("/cart")]
    public Task<IActionResult> GetCurrentOrderAsync()
    {
        var request = new GetCurrentOrderRequest();
        return HandleRequest<GetCurrentOrderRequest, GetCurrentOrderResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllOrdersResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("")]
    public Task<IActionResult> GetAllOrdersAsync()
    {
        var request = new GetAllOrdersRequest();
        return HandleRequest<GetAllOrdersRequest, GetAllOrdersResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetOrdersHistoryResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("history")]
    public Task<IActionResult> GetOrdersHistoryAsync([FromQuery] GetOrdersHistoryRequest request)
    {
        return HandleRequest<GetOrdersHistoryRequest, GetOrdersHistoryResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetOrderByIdResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("{orderId:int}")]
    public Task<IActionResult> GetOrderById(int orderId)
    {
        var request = new GetOrderByIdRequest()
        {
            OrderId = orderId,
        };
        return HandleRequest<GetOrderByIdRequest, GetOrderByIdResponse>(request);
    }

    [HttpGet]
    [ProducesResponseType(typeof(FileStreamResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("pay/bank")]
    public Task<IActionResult> PayOrderByBank()
    {
        var request = new PayOrderByBankRequest();
        return HandleDownloadInvoiceRequest<PayOrderByBankRequest, Stream>(request);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PayOrderByIBoxResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("pay/ibox")]
    public Task<IActionResult> PayOrderByIBox()
    {
        var request = new PayOrderByIBoxRequest();
        return HandleRequest<PayOrderByIBoxRequest, PayOrderByIBoxResponse>(request);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    [Route("pay/visa")]
    public Task<IActionResult> PayOrderByVisa()
    {
        var request = new PayOrderByVisaRequest();
        return HandleRequest<PayOrderByVisaRequest, PayOrderByVisaResponse>(request);
    }
}
