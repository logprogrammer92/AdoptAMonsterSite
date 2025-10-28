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

public class MonsterListViewModel
{
    public required IEnumerable<Monster> Monsters { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public string? SearchTerm { get; set; }
}
