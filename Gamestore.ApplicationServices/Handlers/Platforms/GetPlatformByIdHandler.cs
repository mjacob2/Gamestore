using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.ApplicationServices.Responses.Platofrms;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Platforms;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Platforms;
public class GetPlatformByIdHandler : IRequestHandler<GetPlatformByIdRequest, GetPlatformByIdResponse>
{
    private readonly IQueryExecutor _executor;
    private readonly IMapper _mapper;

    public GetPlatformByIdHandler(IQueryExecutor executor, IMapper mapper)
    {
        _executor = executor;
        _mapper = mapper;
    }

    public async Task<GetPlatformByIdResponse> Handle(GetPlatformByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPlatformByIdQuery()
        {
            PlatformId = request.PlatformId,
        };

        var platformFromDatabase = await _executor.ExecuteQuery(query);

        var mappedPlatform = _mapper.Map<PlatformDetailsModel>(platformFromDatabase);

        var response = new GetPlatformByIdResponse()
        {
            Data = mappedPlatform,
        };

        return response;
    }
}
