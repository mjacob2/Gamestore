using AutoMapper;
using Gamestore.ApplicationServices.Models;
using Gamestore.ApplicationServices.Requests.Comments;
using Gamestore.ApplicationServices.Responses.Comments;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Queries.Comments;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Comments;
public class GetCommentsByGameAliasHandler : IRequestHandler<GetCommentsByGameAliasRequest, GetCommentsByGameAliasResponse>
{
    private readonly IQueryExecutor _executor;
    private readonly IMapper _mapper;

    public GetCommentsByGameAliasHandler(IQueryExecutor executor, IMapper mapper)
    {
        _executor = executor;
        _mapper = mapper;
    }

    public async Task<GetCommentsByGameAliasResponse> Handle(
        GetCommentsByGameAliasRequest request,
        CancellationToken cancellationToken)
    {
        var query = new GetCommentsByGameAliasQuery() { GameAlias = request.GameAlias };

        var commentsFromDatabase = await _executor.ExecuteQuery(query);

        var commentsMappedToModel = _mapper.Map<List<CommentListingModel>>(commentsFromDatabase, opt =>
        {
            opt.Items["UserId"] = request.UserId;
        });

        var response = new GetCommentsByGameAliasResponse() { Data = commentsMappedToModel };

        return response;
    }
}
