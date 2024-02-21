using AutoMapper;
using Gamestore.ApplicationServices.Requests.Comments;
using Gamestore.ApplicationServices.Responses.Comments;
using Gamestore.DataAccess;
using Gamestore.DataAccess.Commands.Comments;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Comments;
public class AddCommentHandler : IRequestHandler<AddCommentRequest, AddCommentResponse>
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IMapper _mapper;

    public AddCommentHandler(ICommandExecutor commandExecutor, IMapper mapper)
    {
        _commandExecutor = commandExecutor;
        _mapper = mapper;
    }

    public async Task<AddCommentResponse> Handle(AddCommentRequest request, CancellationToken cancellationToken)
    {
        var commentToAdd = _mapper.Map<Comment>(request);

        var addCommentCommand = new AddCommentCommand() { Parameter = commentToAdd };

        await _commandExecutor.ExecuteCommand(addCommentCommand);

        var response = new AddCommentResponse()
        {
            Data = request,
        };

        return response;
    }
}