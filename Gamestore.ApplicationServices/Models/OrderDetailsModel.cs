using static Gamestore.DataAccess.Entities.Order;

namespace Gamestore.ApplicationServices.Models;
public class OrderDetailsModel
{
    public int Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public DateTime? PaidDate { get; set; }

    public List<OrderItemDetailsModel> OrderItems { get; set; } = new List<OrderItemDetailsModel>();

    public int Sum { get; set; }

    public float Discount { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }
}
