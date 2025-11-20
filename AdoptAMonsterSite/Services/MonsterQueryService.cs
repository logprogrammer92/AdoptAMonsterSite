namespace AdoptAMonsterSite.Services;

public class MonsterQueryService : IMonsterQueryService
{
    private readonly Data.ApplicationDbContext _context;
    public MonsterQueryService(Data.ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Models.Monster> GetPopularMonsters(int count)
    {
        return _context.Monsters
            .OrderByDescending(m => m.PopularityScore)
            .Take(count)
            .ToList();
    }
    public List<Models.Monster> GetRecentMonsters(int count)
    {
        return _context.Monsters
            .OrderByDescending(m => m.DateAdded)
            .Take(count)
            .ToList();
    }
}
