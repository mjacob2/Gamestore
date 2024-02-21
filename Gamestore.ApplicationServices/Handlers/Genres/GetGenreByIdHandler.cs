using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Genres;
using Gamestore.ApplicationServices.Responses.Genres;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Genres;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Genres;
public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdRequest, GetGenreByIdResponse>
{
    private readonly IQueryExecutor _executor;
    private readonly IMapper _mapper;

    public GetGenreByIdHandler(IQueryExecutor executor, IMapper mapper)
    {
        _executor = executor;
        _mapper = mapper;
    }

    public async Task<GetGenreByIdResponse> Handle(GetGenreByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetGenreByIdQuery()
        {
            GenreId = request.GenreId,
        };

        var genreFromDatabase = await _executor.ExecuteQuery(query);

        var mappedGenre = _mapper.Map<GenreDetailsModel>(genreFromDatabase);
        var response = new GetGenreByIdResponse()
        {
            Data = mappedGenre,
        };

        return response;
    }
}
