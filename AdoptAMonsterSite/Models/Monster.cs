using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptAMonsterSite.Models;

/// <summary>
/// Represents a monster available for adoption.
/// </summary>
public class Monster
{
    /// <summary>
    /// Primary key for the monster.
    /// </summary>
    [Key]
    public int Id { get; set; }
 
    /// <summary>
    /// The display name of the monster.
    /// </summary>
    [Required]
    [StringLength(100, ErrorMessage = "Name cannot be longer than100 characters.")]
    [Display(Name = "Monster Name")]
    public required string Name { get; set; }

    /// <summary>
    /// The species of the monster.
    /// </summary>
    [StringLength(100, ErrorMessage = "Species cannot be longer than100 characters.")]
    [Display(Name = "Species")]
    public string? Species { get; set; }

    /// <summary>
    /// A short description of the monster.
    /// </summary>
    [StringLength(1000, ErrorMessage = "Description cannot be longer than1000 characters.")]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    /// <summary>
    /// The adoption fee for the monster.
    /// </summary>
    [Display(Name = "Adoption Fee")]
    [DataType(DataType.Currency)]
    [Range(0, 1000000, ErrorMessage = "Adoption fee must be a non-negative value and reasonably bounded.")]
    public decimal? AdoptionFee { get; set; }

    /// <summary>
    /// FK to the application user who listed the monster for adoption.
    /// </summary>
    [ForeignKey("ApplicationUser")]
    public string? ApplicationUserID { get; set; } = null;

 /// <summary>
 /// The application user who listed the monster. Nullable to match the foreign key.
 /// </summary>
 public ApplicationUser? ApplicationUser { get; set; } = null;

 /// <summary>
 /// A date for when the monster was added into the system.
 /// </summary>
 [Required]
 [DataType(DataType.DateTime)]
 public DateTime DateAdded { get; set; } = DateTime.UtcNow;

 /// <summary>
 /// A numeric score representing the monster's popularity.
 /// </summary> 
 [Range(0, int.MaxValue, ErrorMessage = "Popularity must be a non-negative integer.")]
 public int PopularityScore { get; set; } = 0;

    /// <summary>
    /// Gets or sets the file name of the image associated with this Monster.
    /// </summary>
    public string? ImageFileName { get; set; } = null;
}

public class MonsterListViewModel
{
 /// <summary>
 /// The list of monsters for the current page.
 /// </summary>
 public required IEnumerable<Monster> Monsters { get; set; }

 /// <summary>
 /// The current page index (1-based).
 /// </summary>
 public int CurrentPage { get; set; }

 /// <summary>
 /// The total number of pages available.
 /// </summary>
 public int TotalPages { get; set; }

 /// <summary>
 /// The page size used for pagination.
 /// </summary>
 public int PageSize { get; set; }

 /// <summary>
 /// The total number of items matching the query.
 /// </summary>
 public int TotalItems { get; set; }

 /// <summary>
 /// The current search term, if any.
 /// </summary>
 public string? SearchTerm { get; set; }
}
