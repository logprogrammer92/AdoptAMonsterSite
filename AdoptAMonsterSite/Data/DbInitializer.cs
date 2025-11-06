using AdoptAMonsterSite.Models;

namespace AdoptAMonsterSite.Data;

public static class DbInitializer
{
    public static void Seed(ApplicationDbContext context)
    {
        if (context.Monsters.Any())
            return;

        var monsters = new List<Monster>
        {
            new Monster { Name = "NibleSnarf", Species = "Leviathan", Description = "Giant Jaw and mouth, very fast.", AdoptionFee =75 },
            new Monster { Name = "Barioth", Species = "Flying Wyvern", Description = "Giant Tiger with wings and sharp fangs", AdoptionFee =50 },
            new Monster { Name = "Gore Magala", Species = "Demi Elder", Description = "Juvenille of Shagura Magala", AdoptionFee =90 }
        };

        context.Monsters.AddRange(monsters);
        context.SaveChanges();
    }
}
