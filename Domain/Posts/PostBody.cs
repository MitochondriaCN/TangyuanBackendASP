using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Posts;

public sealed record PostBody
{
    public PostBody(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("帖子内容不能为空");

        Value = value.Trim();
    }

    public string Value { get; }

    public override string ToString() => Value;
}