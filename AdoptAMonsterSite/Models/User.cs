using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptAMonsterSite.Models;

public class ApplicationUser : IdentityUser
{
    //Custom Fields can go here in the future
    public required string DisplayName { get; set; } = string.Empty;

}
