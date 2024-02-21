using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;
public class Shipper
{
    [Key]
    [MaxLength(100)]
    public string ShipperId { get; set; }

    [Required]
    [StringLength(50)]
    public string CompanyName { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }
}
