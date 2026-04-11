using System.Text.RegularExpressions;
using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Users;

public sealed record EmailAddress
{
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("邮箱不能为空");

        var normalized = value.Trim();
        if (!Regex.IsMatch(normalized, EmailPattern))
            throw new DomainException("邮箱格式错误");

        Value = normalized;
    }

    public string Value { get; }

    public override string ToString() => Value;
}