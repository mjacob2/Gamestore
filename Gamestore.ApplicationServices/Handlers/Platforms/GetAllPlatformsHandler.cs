using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Platforms;
using Gamestore.ApplicationServices.Responses.Platofrms;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Platforms;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Platforms;
public class GetAllPlatformsHandler : IRequestHandler<GetAllPlatformsRequest, GetAllPlatformsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _executor;

    public GetAllPlatformsHandler(IMapper mapper, IQueryExecutor executor)
    {
        _mapper = mapper;
        _executor = executor;
    }

    public async Task<GetAllPlatformsResponse> Handle(GetAllPlatformsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllPlatformsQuery();
        var platformsFromDb = await _executor.ExecuteQuery(query);
        var mappedPlatforms = _mapper.Map<List<PlatformListingModel>>(platformsFromDb);
        var response = new GetAllPlatformsResponse()
        {
            Data = mappedPlatforms,
        };

        return response;
    }
}
