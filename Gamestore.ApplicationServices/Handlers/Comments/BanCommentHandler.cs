using Gamestore.ApplicationServices.Requests.Comments;
using Gamestore.ApplicationServices.Responses.Comments;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Comments;
using Gamestore.DataAccess.Entities;
using Gamestore.DataAccess.Queries.Comments;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Comments;
public class BanCommentHandler : IRequestHandler<BanCommentRequest, BanCommentResponse>
{
    private const int PermanentBanInYears = 100;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public BanCommentHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<BanCommentResponse> Handle(BanCommentRequest request, CancellationToken cancellationToken)
    {
        var commentToBan = await _queryExecutor.ExecuteQuery(new GetCommentByIdQuery() { CommentId = request.CommentId });

        if (request.BanDuration != Comment.CommentBanDuration.Permanent)
        {
            var banDurationInHours = (int)request.BanDuration;
            commentToBan.BanUntil = DateTime.UtcNow.AddHours(banDurationInHours);
        }
        else
        {
            commentToBan.BanUntil = DateTime.UtcNow.AddYears(PermanentBanInYears);
        }

        var addCommentCommand = new BanCommentCommand() { Parameter = commentToBan };

        await _commandExecutor.ExecuteCommand(addCommentCommand);

        var response = new BanCommentResponse()
        {
            Data = $"Comment ID: {commentToBan.Id} banned until {commentToBan.BanUntil}",
        };

        return response;
    }
}
