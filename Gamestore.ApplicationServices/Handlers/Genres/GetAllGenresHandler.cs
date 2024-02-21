using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.ApplicationServices.Responses.Genres;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Genres;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Genres;
public class GetAllGenresHandler : IRequestHandler<GetAllGenresRequest, GetAllGenresResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _executor;

    public GetAllGenresHandler(IMapper mapper, IQueryExecutor executor)
    {
        _mapper = mapper;
        _executor = executor;
    }

    public async Task<GetAllGenresResponse> Handle(GetAllGenresRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllGenresQuery();
        var genresFromDb = await _executor.ExecuteQuery(query);
        var mappedGenres = _mapper.Map<List<GenreListingModel>>(genresFromDb);
        var response = new GetAllGenresResponse()
        {
            Data = mappedGenres,
        };

        return response;
    }
}
