using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Users;

public sealed record IsoRegionCode
{
    private static readonly HashSet<string> SupportedCodes = ["CN", "US", "IN"];

    public IsoRegionCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("区域编码不能为空");

        var normalized = value.Trim().ToUpperInvariant();
        if (!SupportedCodes.Contains(normalized))
            throw new DomainException("不支持的区域编码");

        Value = normalized;
    }

    public string Value { get; }

    public string PhonePattern => Value switch
    {
        "CN" => @"^(\+?0?86\-?)?1[345789]\d{9}$",
        "US" => @"^\+?1?\d{10}$",
        "IN" => @"^\+?91?\d{10}$",
        _ => throw new DomainException("不支持的区域编码")
    };

    public override string ToString() => Value;
}