using System.Text.RegularExpressions;
using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Users;

public sealed record PhoneNumber
{
    public PhoneNumber(string value, IsoRegionCode regionCode)
    {
        Value = Normalize(value);

        if (!Regex.IsMatch(Value, regionCode.PhonePattern))
            throw new DomainException("手机号格式错误");
    }

    private PhoneNumber(string normalizedValue)
    {
        Value = normalizedValue;
    }

    public string Value { get; }

    public static PhoneNumber Restore(string value)
    {
        return new PhoneNumber(Normalize(value));
    }

    private static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("手机号不能为空");

        return value.Trim();
    }

    public override string ToString() => Value;
}