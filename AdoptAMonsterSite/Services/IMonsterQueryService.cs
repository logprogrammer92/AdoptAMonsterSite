namespace AdoptAMonsterSite.Services;

/// <summary>
/// Defines query operations for retrieving monsters from the application data store.
/// </summary>
public interface IMonsterQueryService
{
    /// <summary>
    /// Retrieves the most popular monsters ordered by popularity score.
    /// </summary>
    /// <param name="count">The maximum number of monsters to return.</param>
    /// <returns>A list of the most popular <see cref="Models.Monster"/> instances limited by <paramref name="count"/>.</returns>
    List<Models.Monster> GetPopularMonsters(int count);

    /// <summary>
    /// Retrieves the most recently added monsters ordered by date added.
    /// </summary>
    /// <param name="count">The maximum number of monsters to return.</param>
    /// <returns>A list of the most recent <see cref="Models.Monster"/> instances limited by <paramref name="count"/>.</returns>
    List<Models.Monster> GetRecentMonsters(int count);
}
