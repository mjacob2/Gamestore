namespace Gamestore.ApplicationServices.Models;
public class CommentListingModel
{
    public int Id { get; set; }

    public string AuthorName { get; set; }

    public string Body { get; set; }

    public bool CanBeDeletedByUser { get; set; }

    public int? AsReplyTo { get; set; }

    public int? AsQuoteTo { get; set; }

    public DateTime? BanUntil { get; set; }
}
