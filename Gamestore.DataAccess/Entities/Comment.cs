using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.DataAccess.Entities;
public class Comment
{
    /// <summary>
    /// Comment ban duration in hours.
    /// </summary>
    public enum CommentBanDuration
    {
        OneHour = 1,
        OneDay = 24,
        OneWeek = 168,
        OneMonth = 720,
        Permanent = -1,
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string AuthorName { get; set; } = string.Empty;

    [Required]
    [MaxLength(500)]
    public string Body { get; set; } = string.Empty;

    public DateTime? BanUntil { get; set; }

    [Required]
    public string GameAlias { get; set; }

    [ForeignKey("GameAlias")]
    public virtual Game Game { get; set; }

    [MaxLength(100)]
    public string UserId { get; set; }

    public int? AsReplyToCommentId { get; set; }

    public int? AsQuoteToCommentId { get; set; }
}
