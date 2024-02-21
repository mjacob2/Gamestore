using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Publishers;
using Gamestore.ApplicationServices.Responses.Publishers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Publishers;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Publishers;
public class GetAllPublishersHandler : IRequestHandler<GetAllPublishersRequest, GetAllPublishersResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _executor;

    public GetAllPublishersHandler(IMapper mapper, IQueryExecutor executor)
    {
        _mapper = mapper;
        _executor = executor;
    }

    public async Task<GetAllPublishersResponse> Handle(GetAllPublishersRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllPublishersQuery();
        var publishersFromDb = await _executor.ExecuteQuery(query);
        var mappedPublishers = _mapper.Map<List<PublisherListingModel>>(publishersFromDb);
        var response = new GetAllPublishersResponse()
        {
            Data = mappedPublishers,
        };

        return response;
    }
}