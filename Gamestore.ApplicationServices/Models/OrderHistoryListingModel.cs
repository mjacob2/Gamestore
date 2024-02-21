namespace Gamestore.ApplicationServices.Models;
public class OrderHistoryListingModel
{
    public int Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }
}
