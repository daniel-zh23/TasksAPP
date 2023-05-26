using System.Security.Claims;

namespace TasksAPI.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static string Id(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}