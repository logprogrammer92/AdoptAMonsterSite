using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptAMonsterSite.Models;

public class Monster
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Display (Name = "Monster Name")]
    public required string Name { get; set; }

    [Display (Name = "Species")]
    public string? Species { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "AdoptionFee")]
    [DataType(DataType.Currency)]
    public decimal? Price { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; } = string.Empty;
    public ApplicationUser ApplicationUser { get; set; } = null;
}
