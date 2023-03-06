using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SingleDailyBugle.Models;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string PossibleRoles { get; set; } = string.Empty;
}
