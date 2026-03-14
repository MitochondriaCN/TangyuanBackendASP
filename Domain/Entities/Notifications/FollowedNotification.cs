namespace TangyuanBackendASP.Domain.Entities.Notifications;

/// <summary>
/// 被关注通知
/// </summary>
public class FollowedNotification : Notification
{
    private FollowedNotification()
    {
    }

    public FollowedNotification(long targetUserId, long sourceUserId) : base(targetUserId)
    {
        SourceUserId = sourceUserId;
    }

    /// <summary>
    /// 源用户ID
    /// </summary>
    public long SourceUserId { get; private set; }
}