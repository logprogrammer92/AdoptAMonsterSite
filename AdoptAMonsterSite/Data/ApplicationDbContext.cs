using AdoptAMonsterSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdoptAMonsterSite.Data;

/// <summary>
/// Entity Framework Core database context for the application, including Identity and monster listings.
/// </summary>
/// <remarks>
/// This context derives from <see cref="IdentityDbContext{TUser}"/> to include ASP.NET Core Identity schema for <see cref="ApplicationUser"/>.
/// Register this context as scoped in the DI container (the default for DbContext), and avoid using it concurrently from multiple threads.
/// </remarks>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the monster listings tracked by the application.
    /// </summary>
    public DbSet<Monster> Monsters { get; set; }

    /// <summary>
    /// Configures the EF Core model for the application.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure entity mappings and constraints.</param>
    /// <remarks>
    /// This method configures a unique index on the <see cref="Monster.Name"/> property to prevent duplicate monster names.
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Monster>()
            .HasIndex(m => m.Name)
            .IsUnique();
    }
}
