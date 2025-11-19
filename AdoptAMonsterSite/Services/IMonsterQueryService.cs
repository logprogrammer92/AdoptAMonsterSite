namespace AdoptAMonsterSite.Services;

public interface IMonsterQueryService
{
    List<Models.Monster> GetPopularMonsters(int count);
    List<Models.Monster> GetRecentMonsters(int count);
}
