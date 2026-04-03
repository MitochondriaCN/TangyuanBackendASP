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

    public Post(long userId, string textContent, long categoryId, DateTime postDateTime, params string[] imageGuids)
    {
        if (imageGuids.Length > 3)
            throw new ArgumentException("一条帖子最多只能有三张图片");

        PostId = SnowflakeUtils.GenerateSnowflakeId();
        UserId = userId;
        TextContent = textContent;
        CategoryId = categoryId;
        ImageGuids = imageGuids;
        PostDateTime = postDateTime;
        IsVisible = true;
    }

    public long PostId { get; private set; }

    public long UserId { get; private set; }

    /// <summary>
    /// 帖子发布时间
    /// <remarks>
    /// 只代表帖子语义上的时间，并不代表帖子创建时间
    /// </remarks>
    /// </summary>
    public DateTime PostDateTime { get; private set; }

    public long CategoryId { get; private set; }

    public bool IsVisible { get; private set; }

    public string TextContent { get; private set; } = null!;

    public string[] ImageGuids { get; private set; } = null!;
}