using Gamestore.ApplicationServices.Responses.Comments;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Comments;
public class DeleteCommentByIdRequest : IRequest<DeleteCommentByIdResponse>
{
    public required int CommentId { get; set; }

    public string? UserId { get; set; }
}
