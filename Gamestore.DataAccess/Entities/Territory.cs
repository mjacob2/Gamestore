using System.ComponentModel.DataAnnotations;

namespace Gamestore.DataAccess.Entities;
public class Territory
{
    [Key]
    public int TerritoryID { get; set; }

    [Required]
    [StringLength(50)]
    public string TerritoryDescription { get; set; }

    public int RegionID { get; set; }
}
