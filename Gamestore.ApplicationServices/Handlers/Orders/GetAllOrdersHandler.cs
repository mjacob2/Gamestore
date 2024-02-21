using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Orders;
using Gamestore.ApplicationServices.Responses.Orders;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Orders;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Orders;
public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, GetAllOrdersResponse>
{
    private readonly IQueryExecutor _queryExecutor;
    private readonly IMapper _mapper;

    public GetAllOrdersHandler(IQueryExecutor queryExecutor, IMapper mapper)
    {
        _queryExecutor = queryExecutor;
        _mapper = mapper;
    }

    public async Task<GetAllOrdersResponse> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllPaidOrdersQuery() { CustomerId = request.CustomerId };
        var ordersFromDatabase = await _queryExecutor.ExecuteQuery(query);

        var ordersMappedToModel = _mapper.Map<List<OrderDetailsModel>>(ordersFromDatabase);
        var response = new GetAllOrdersResponse() { Data = ordersMappedToModel };

        return response;
    }
}