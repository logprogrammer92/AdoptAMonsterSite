namespace AdoptAMonsterSite.Services;

/// <summary>
/// Default implementation of <see cref="IMonsterQueryService"/> that queries monsters from the <see cref="Data.ApplicationDbContext"/>.
/// </summary>
/// <remarks>
/// This service depends on <see cref="Data.ApplicationDbContext"/> and therefore should be registered with a scoped lifetime.
/// The implementation is not thread-safe because <see cref="Data.ApplicationDbContext"/> is not thread-safe.
/// </remarks>
public class MonsterQueryService : IMonsterQueryService
{
    private readonly Data.ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="MonsterQueryService"/> class.
    /// </summary>
    /// <param name="context">The application database context used for queries.</param>
    public MonsterQueryService(Data.ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves the most popular monsters ordered by popularity score.
    /// </summary>
    /// <param name="count">The maximum number of monsters to return.</param>
    /// <returns>A list of the most popular <see cref="Models.Monster"/> instances limited by <paramref name="count"/>.</returns>
    public List<Models.Monster> GetPopularMonsters(int count)
    {
        return _context.Monsters
            .OrderByDescending(m => m.PopularityScore)
            .Take(count)
            .ToList();
    }

    /// <summary>
    /// Retrieves the most recently added monsters ordered by date added.
    /// </summary>
    /// <param name="count">The maximum number of monsters to return.</param>
    /// <returns>A list of the most recent <see cref="Models.Monster"/> instances limited by <paramref name="count"/>.</returns>
    public List<Models.Monster> GetRecentMonsters(int count)
    {
        return _context.Monsters
            .OrderByDescending(m => m.DateAdded)
            .Take(count)
            .ToList();
    }
}
