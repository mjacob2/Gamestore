using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
public class GetCurrentOrderHandler : IRequestHandler<GetCurrentOrderRequest, GetCurrentOrderResponse>
{
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;

    public GetCurrentOrderHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetCurrentOrderResponse> Handle(GetCurrentOrderRequest request, CancellationToken cancellationToken)
    {
        var query = new GetCurrentOrderByCustomerIdQuery() { CustomerId = request.CustomerId };
        var orderFromDatabase = await _queryExecutor.ExecuteQuery(query);

        var orderMappedToModel = _mapper.Map<OrderDetailsModel>(orderFromDatabase);
        var response = new GetCurrentOrderResponse() { Data = orderMappedToModel };

        return response;
    }
}
