using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gamestore.API.Controllers;

public class ApiControllerBase : ControllerBase
{
    private readonly IMediator _mediator;

    protected ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
                    where TRequest : IRequest<TResponse>
    {
        var responseFromHandler = await _mediator.Send(request);

        return Ok(responseFromHandler);
    }

    protected async Task<IActionResult> HandleDownloadInvoiceRequest<TRequest, TResponse>(TRequest request)
    where TRequest : IRequest<Stream>
    where TResponse : Stream
    {
        var stream = await _mediator.Send(request);

        return new FileStreamResult(stream, "application/octet-stream")
        {
            FileDownloadName = "Invoice.pdf",
        };
    }

    protected async Task<IActionResult> HandleDownloadGameRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<Stream>
        where TResponse : Stream
    {
        var stream = await _mediator.Send(request);

        var response = new FileStreamResult(stream, "text/plain");
        return response;
    }
}
