using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptAMonsterSite.Models;

/// <summary>
/// Application-specific user that extends ASP.NET Core Identity's <see cref="IdentityUser"/>.
/// </summary>
/// <remarks>
/// Add additional profile fields to this class as needed. Identity will persist these properties in the ASP.NET Core Identity store.
/// </remarks>
public class ApplicationUser : IdentityUser
{
    // Custom Fields can go here in the future

    /// <summary>
    /// Gets or sets the display name shown in the UI for the user.
    /// </summary>
    /// <remarks>
    /// This property is required for display purposes and defaults to an empty string to avoid null values.
    /// </remarks>
    public required string DisplayName { get; set; } = string.Empty;
}
