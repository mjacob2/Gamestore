using Gamestore.ApplicationServices.Requests.Comments;
using Gamestore.ApplicationServices.Responses.Comments;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Comments;
using Gamestore.DataAccess.Exceptions;
using Gamestore.DataAccess.Queries.Comments;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Comments;
public class DeleteCommentByIdHandler : IRequestHandler<DeleteCommentByIdRequest, DeleteCommentByIdResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public DeleteCommentByIdHandler(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<DeleteCommentByIdResponse> Handle(DeleteCommentByIdRequest request, CancellationToken cancellationToken)
    {
        var commentToDelete = await _queryExecutor.ExecuteQuery(new GetCommentByIdQuery() { CommentId = request.CommentId });

        if (commentToDelete.UserId != request.UserId)
        {
            throw new UnauthorizedException("You can't delete this comment");
        }

        var command = new DeleteCommentByIdCommand() { Parameter = commentToDelete };

        await _commandExecutor.ExecuteCommand(command);

        var response = new DeleteCommentByIdResponse()
        {
            Data = "A comment/quote was deleted",
        };

        return response;
    }
}