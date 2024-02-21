using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Publishers;
using Gamestore.ApplicationServices.Responses.Publishers;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Publishers;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Publishers;
public class GetPublisherByIdHandler : IRequestHandler<GetPublisherByIdRequest, GetPublisherByIdResponse>
{
    private readonly IQueryExecutor _executor;
    private readonly IMapper _mapper;

    public GetPublisherByIdHandler(IQueryExecutor executor, IMapper mapper)
    {
        _executor = executor;
        _mapper = mapper;
    }

    public async Task<GetPublisherByIdResponse> Handle(GetPublisherByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPublisherByIdQuery()
        {
            PublisherId = request.PublisherId,
        };

        var publisherFromDataBase = await _executor.ExecuteQuery(query);

        var mappedPublisher = _mapper.Map<PublisherDetailsModel>(publisherFromDataBase);

        var response = new GetPublisherByIdResponse()
        {
            Data = mappedPublisher,
        };

        return response;
    }
}