using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;
public class Order
{
    public enum OrderStatus
    {
        Open,
        Checkout,
        Paid,
        Shipped,
        Canceled,
    }

    [Key]
    public int Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public DateTime? PaidDate { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public int Sum { get; set; }

    public float Discount { get; set; }

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public string ShipCountry { get; set; }

    public string ShipPostalCode { get; set; }

    public string ShipRegion { get; set; }

    public string ShipCity { get; set; }

    public string ShipAddress { get; set; }

    public string ShipName { get; set; }

    public double Freight { get; set; }

    public int ShipVia { get; set; }

    public DateTime ShippedDate { get; set; }

    public DateTime RequiredDate { get; set; }
}
