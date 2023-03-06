using System.ComponentModel.DataAnnotations;

namespace SingleDailyBugle.Models.DTOs;

public class AuthenticationRequest
{
    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
