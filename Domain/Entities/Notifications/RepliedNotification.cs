namespace TangyuanBackendASP.Domain.Entities.Notifications;

/// <summary>
/// 评论被回复通知
/// </summary>
public class RepliedNotification : Notification
{
    private RepliedNotification()
    {
    }

    public RepliedNotification(long targetUserId, long sourceCommentId) : base(targetUserId)
    {
        SourceCommentId = sourceCommentId;
    }

    /// <summary>
    /// 源评论ID
    /// </summary>
    public long SourceCommentId { get; private set; }
}