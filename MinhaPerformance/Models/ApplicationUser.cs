using Microsoft.AspNetCore.Identity;

namespace MinhaPerformance.Models;

public class ApplicationUser : IdentityUser
{
    public virtual string PictureURL { get; set; } = "";
}

