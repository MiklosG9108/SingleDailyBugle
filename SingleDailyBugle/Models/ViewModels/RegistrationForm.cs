using Microsoft.Build.Framework;

namespace SingleDailyBugle.Models.ViewModels;

public class RegistrationForm
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Role { get; set; } = string.Empty;
}
