using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Users;

public sealed record Nickname
{
    public Nickname(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("昵称不能为空");

        var normalized = value.Trim();
        if (normalized.Length > 10)
            throw new DomainException("昵称长度不能超过10个字符");

        Value = normalized;
    }

    public string Value { get; }

    public override string ToString() => Value;
}