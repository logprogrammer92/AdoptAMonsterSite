using System.Collections.Generic;

namespace AdoptAMonsterSite.Models.ViewModels;

public class HomeIndexViewModel
{
    // Initialize lists to avoid non-nullable property warnings
    public List<Monster> PopularMonsters { get; set; } = new();
    public List<Monster> RecentMonsters { get; set; } = new();
}
