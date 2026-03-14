namespace TangyuanBackendASP.Domain.Entities.Notifications;

/// <summary>
/// 系统通知
/// </summary>
public class SystemNotification : Notification
{
    private SystemNotification()
    {
    }

    public SystemNotification(long targetUserId, string message) : base(targetUserId)
    {
        Message = message;
    }

    /// <summary>
    /// 通知消息
    /// </summary>
    public string Message { get; private set; } = null!;
}