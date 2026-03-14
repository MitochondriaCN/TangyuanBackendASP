namespace TangyuanBackendASP.Domain.Entities.Notifications;

/// <summary>
/// 被提及通知
/// </summary>
public class MentionedNotification : Notification
{
    private MentionedNotification()
    {
    }

    public MentionedNotification(long targetUserId, long sourceUserId) : base(targetUserId)
    {
        SourceUserId = sourceUserId;
    }

    /// <summary>
    /// 源用户ID
    /// </summary>
    public long SourceUserId { get; private set; }
}