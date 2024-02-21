using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Comments;
public class AddCommentCommand : CommandBase<Comment, Comment>
{
    public override async Task<Comment> Execute(GamestoreDbContext context)
    {
        await context.Comments.AddAsync(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
