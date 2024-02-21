using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.DataAccess.Entities;
public class Product
{
    [Key]
    [Required]
    [StringLength(50)]
    public string Id { get; set; }

    public int ProductID { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductName { get; set; }

    public int SupplierID { get; set; }

    public int CategoryID { get; set; }

    public Category Category { get; set; }

    [StringLength(100)]
    public string QuantityPerUnit { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public int UnitsOnOrder { get; set; }

    public int ReorderLevel { get; set; }

    public bool Discontinued { get; set; }
}
