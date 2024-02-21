using Gamestore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Queries.Comments;
public class GetCommentByIdQuery : QueryBase<Comment>
{
    public required int CommentId { get; set; }

    public override async Task<Comment> Execute(GamestoreDbContext context)
    {
        return await context.Comments
            .FirstOrDefaultAsync(c => c.Id == CommentId);
    }
}