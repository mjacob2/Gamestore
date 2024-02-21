using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;
public class Category
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(50)]
    public string CategoryName { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    public byte[] Picture { get; set; }

    public List<Product> Products { get; set; }
}
