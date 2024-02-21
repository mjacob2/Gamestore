using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Comments;
using Gamestore.DataAccess.Entities;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Comments;
public class BanCommentRequest : IRequest<BanCommentResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    public required int CommentId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public required Comment.CommentBanDuration BanDuration { get; set; }
}
