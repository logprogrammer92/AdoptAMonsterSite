using AdoptAMonsterSite.Models;

namespace AdoptAMonsterSite.Data;

/// <summary>
/// Provides helper methods to seed the application's database with initial data.
/// </summary>
/// <remarks>
/// The seeding performed by this class is idempotent: calling <see cref="Seed(ApplicationDbContext)"/>
/// multiple times will not create duplicate monster records because the method checks for existing data.
/// This helper is typically called during application startup when ensuring a development or test
/// database contains sample data.
/// </remarks>
public static class DbInitializer
{
    /// <summary>
    /// Ensures the database contains initial monster records.
    /// </summary>
    /// <param name="context">The application database context to use for seeding.</param>
    /// <remarks>
    /// This method will return immediately if any monsters already exist in the database.
    /// It calls <see cref="DbContext.SaveChanges"/> after adding sample entities.
    /// </remarks>
    /// <example>
    /// <code>
    /// using var scope = app.Services.CreateScope();
    /// var db = scope.ServiceProvider.GetRequiredService&lt;ApplicationDbContext&gt;();
    /// DbInitializer.Seed(db);
    /// </code>
    /// </example>
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
