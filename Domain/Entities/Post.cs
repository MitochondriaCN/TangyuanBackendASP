using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Shared.Utils;

namespace TangyuanBackendASP.Domain.Entities;

/// <summary>
/// 帖子
/// </summary>
public class Post
{
    private Post()
    {
    }

    public Post(long userId, string textContent, long categoryId, params string[] imageGuids)
    {
        if (imageGuids.Length > 3)
            throw new ArgumentException("一条帖子最多只能有三张图片");

        PostId = SnowflakeUtils.GenerateSnowflakeId();
        UserId = userId;
        TextContent = textContent;
        CategoryId = categoryId;
        ImageGuids = imageGuids;
        PostDateTime = DateTime.UtcNow;
        IsVisible = true;
    }

    public long PostId { get; private set; }

    public long UserId { get; private set; }

    public DateTime PostDateTime { get; private set; }

    public long CategoryId { get; private set; }

    public bool IsVisible { get; private set; }

    public string TextContent { get; private set; } = null!;

    public string[] ImageGuids { get; private set; } = null!;
}