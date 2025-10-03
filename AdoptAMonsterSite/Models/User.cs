using Microsoft.AspNetCore.Identity;

namespace AdoptAMonsterSite.Models;

public class ApplicationUser : IdentityUser
{
    //Custom Fields can go here in the future
    public required string DisplayName { get; set; }
}
