using System.ComponentModel.DataAnnotations;
using Gamestore.ApplicationServices.Responses.Comments;
using MediatR;

namespace Gamestore.ApplicationServices.Requests.Comments;
public class AddCommentRequest : IRequest<AddCommentResponse>
{
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string AuthorName { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(500)]
    public string Body { get; set; } = string.Empty;

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(100)]
    public string GameAlias { get; set; }

    public string? UserId { get; set; }

    public int? AsReplyTo { get; set; }

    public int? AsQuoteTo { get; set; }
}
