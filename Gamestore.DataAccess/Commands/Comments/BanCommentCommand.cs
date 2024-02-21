using Gamestore.DataAccess.Entities;

namespace Gamestore.DataAccess.Commands.Comments;
public class BanCommentCommand : CommandBase<Comment, Comment>
{
    public override async Task<Comment> Execute(GamestoreDbContext context)
    {
        context.Comments.Update(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}
