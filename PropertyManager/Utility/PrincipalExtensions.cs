using System.Security.Claims;

namespace PropertyManager.Utility;

public static class PrincipalExtensions
{
    public static string GetUserName(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {
            throw new ArgumentException(nameof(principal));
        }

        return principal.FindFirstValue(ClaimTypes.Name);
    }

    public static long GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
        {   
            throw new ArgumentException(nameof(principal));
        }
            
        return long.Parse(principal.FindFirstValue("UserId"));
    }

    public static string GetUserProp(this ClaimsPrincipal principal, string propName)
    {
        return "";
    }
}