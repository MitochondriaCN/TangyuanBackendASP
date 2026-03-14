using System.Text.RegularExpressions;

namespace TangyuanBackendASP.Shared.Utils;

public static class StringValidateUtils
{
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return Regex.IsMatch(email, EmailPattern);
    }

    public static bool IsValidGuid(string guid)
    {
        return Guid.TryParse(guid, out _);
    }
}