using Microsoft.AspNetCore.Identity;
using SingleDailyBugle.Models.DTOs;

namespace SingleDailyBugle.Services
{
    public interface ITokenCreationService
    {
        AuthenticationResponse CreateToken(IdentityUser user, IList<string> roles);
    }
}