using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Gamestore.DataAccess.Commands.Comments;
public class DeleteCommentByIdCommand : CommandBase<Comment, Comment>
{
    public override async Task<Comment> Execute(GamestoreDbContext context)
    {
        var commentToDelete = await context.Comments.FirstOrDefaultAsync(x => x.Id == Parameter.Id);

        if (commentToDelete == null)
        {
            throw new NotFoundException($"Comment id: {Parameter.Id}. ");
        }

        context.Comments.Remove(commentToDelete);
        await context.SaveChangesAsync();
        return commentToDelete;
    }
}
