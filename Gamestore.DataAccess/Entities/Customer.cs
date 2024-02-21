using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;
public class Customer
{
    [Key]
    [StringLength(50)]
    public string CustomerID { get; set; }

    [Required]
    [StringLength(50)]
    public string CompanyName { get; set; }

    [StringLength(50)]
    public string ContactName { get; set; }

    [StringLength(50)]
    public string ContactTitle { get; set; }

    [StringLength(100)]
    public string Address { get; set; }

    [StringLength(50)]
    public string City { get; set; }

    [StringLength(50)]
    public string Region { get; set; }

    public int PostalCode { get; set; }

    [StringLength(50)]
    public string Country { get; set; }

    [StringLength(50)]
    public string Phone { get; set; }

    [StringLength(50)]
    public string Fax { get; set; }
}
