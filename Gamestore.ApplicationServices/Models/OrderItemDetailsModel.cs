namespace Gamestore.ApplicationServices.Models;
public class OrderItemDetailsModel
{
    public int Id { get; set; }

    public string ProductId { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal ProductPrice { get; set; }

    public int OrderId { get; set; }
}
