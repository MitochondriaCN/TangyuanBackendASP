using Microsoft.EntityFrameworkCore;

namespace TangyuanBackendASP.Domain.Entities;

/// <summary>
/// 评论
/// </summary>
public class Comment
{
    private Comment()
    {
    }

    public Comment(string content, long postId, long userId, long parentCommentId = 0)
    {
        PostId = postId;
        UserId = userId;
        ParentCommentId = parentCommentId;
        Content = content;
        CommentDateTime = DateTime.UtcNow;
    }

    /// <summary>
    /// 评论ID
    /// </summary>
    public long CommentId { get; private set; }

    /// <summary>
    /// 父评论ID，若为根评论则为0
    /// </summary>
    public long ParentCommentId { get; private set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    public long UserId { get; private set; }

    /// <summary>
    /// 所属帖子ID
    /// </summary>
    public long PostId { get; private set; }

    /// <summary>
    /// 评论内容
    /// </summary>
    public string Content { get; private set; } = null!;

    /// <summary>
    /// 评论图片GUID
    /// </summary>
    public string? ImageGuid { get; private set; }

    /// <summary>
    /// 评论时间
    /// </summary>
    public DateTime CommentDateTime { get; private set; }

    public void UpdateImageGuid(string imageGuid)
    {
        ImageGuid = imageGuid;
    }
}