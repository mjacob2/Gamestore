using Gamestore.ApplicationServices.Requests.Users;
using Gamestore.ApplicationServices.Responses.Users;
using MediatR;

namespace Gamestore.ApplicationServices.Handlers.Users;
public class BanUserFromCommentHandler : IRequestHandler<BanUserFromCommentRequest, BanUserFromCommentResponse>
{
    public Task<BanUserFromCommentResponse> Handle(BanUserFromCommentRequest request, CancellationToken cancellationToken)
    {
        // Not yet implemented according to requirements Epic 4, UserStory 5.
        var response = new BanUserFromCommentResponse() { Data = request };
        var task = Task.FromResult(response);
        return task;
    }
}
