using System.Security.Claims;

namespace SingleDailyBugle.Extensions
{
    internal static class ClaimsPrincipalExtensions
    {
        public static string GetCurrentUserId(this ClaimsPrincipal user)
        {
            ArgumentNullException.ThrowIfNull(user);

            // NOTE: how to get user's id?
            // https://stackoverflow.com/questions/30701006/how-to-get-the-current-logged-in-user-id-in-asp-net-core
            return user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new InvalidOperationException("Current user id is null.");
        }
    }
}
