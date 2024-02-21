using Gamestore.ApplicationServices.Responses.Comments;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Comments;
public class GetCommentsByGameAliasRequest : IRequest<GetCommentsByGameAliasResponse>
{
    public required string GameAlias { get; set; }

    public string? UserId { get; set; }
}
