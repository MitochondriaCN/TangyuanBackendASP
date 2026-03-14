using TangyuanBackendASP.Shared.Utils;

namespace TangyuanBackendASP.Domain.Entities.Notifications;

/// <summary>
/// 帖子被评论通知
/// </summary>
public class CommentedNotification : Notification
{
    private CommentedNotification()
    {
    }

    public CommentedNotification(long targetUserId, long sourceCommentId) : base(targetUserId)
    {
        SourceCommentId = sourceCommentId;
    }

    /// <summary>
    /// 源评论ID
    /// </summary>
    public long SourceCommentId { get; private set; }
}