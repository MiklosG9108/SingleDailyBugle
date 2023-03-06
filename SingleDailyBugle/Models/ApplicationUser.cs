using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SingleDailyBugle.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string Role { get; set; } = string.Empty;
}
