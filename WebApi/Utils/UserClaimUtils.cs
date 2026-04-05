using System.Security.Claims;

namespace TangyuanBackendASP.WebApi.Utils;

public static class UserClaimUtils
{
    public static long GetUserId(this ClaimsPrincipal claims)
    {
        return long.Parse(claims.FindFirst(ClaimTypes.NameIdentifier)?.Value ??
                          throw new InvalidOperationException("User ID claim not found."));
    }
}