using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Users;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Users;
public class BanUserFromCommentRequest : IRequest<BanUserFromCommentResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Comment.CommentBanDuration BanDuration { get; set; }
}
