using System.ComponentModel.DataAnnotations;

namespace AdoptAMonsterSite.Models;

public class Monster
{
    public int Id { get; set; }
    
    [Required]
    [Display (Name = "Monster Name")]
    public required string Name { get; set; }

    [Display (Name = "Species")]
    public string? Species { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }
    
    [Display (Name = "AdoptionFee")]
    [DataType (DataType.Currency)]
    public decimal? Price { get; set; }
}
