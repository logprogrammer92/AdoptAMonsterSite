namespace AdoptAMonsterSite.Services;

public class MonsterQueryService
{
    private readonly Data.ApplicationDbContext _context;
    public MonsterQueryService(Data.ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Models.Monster> GetPopularMonsters(int count)
    {
        return _context.Monsters
            .OrderByDescending(m => m.Id) //TODO: Implement popularity logic
            .Take(count)
            .ToList();
    }
    public List<Models.Monster> GetRecentMonsters(int count)
    {
        return _context.Monsters
            .OrderByDescending(m => m.Id) //TODO: Implement recent logic
            .Take(count)
            .ToList();
    }
}
