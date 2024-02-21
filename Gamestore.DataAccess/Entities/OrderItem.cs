using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;

public class OrderItem
{
    [Key]
    public int Id { get; set; }

    public string ProductId { get; set; } = string.Empty;

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal ProductPrice { get; set; }

    public Order Order { get; set; }

    public int OrderId { get; set; }
}
