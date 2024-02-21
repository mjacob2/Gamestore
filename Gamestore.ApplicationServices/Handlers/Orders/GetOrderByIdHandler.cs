using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
{
    private readonly IQueryExecutor _executor;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(IQueryExecutor executor, IMapper mapper)
    {
        _executor = executor;
        _mapper = mapper;
    }

    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetOrderByIdQuery()
        {
            OrderId = request.OrderId,
        };

        var orderFromDatabase = await _executor.ExecuteQuery(query);

        var mappedOrder = _mapper.Map<OrderDetailsModel>(orderFromDatabase);

        var response = new GetOrderByIdResponse()
        {
            Data = mappedOrder,
        };

        return response;
    }
}