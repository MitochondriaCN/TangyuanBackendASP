using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Domain.Enums;
using TangyuanBackendASP.Shared.Utils;

namespace TangyuanBackendASP.Domain.Entities.Notifications;

public abstract class Notification
{
    protected Notification()
    {
    }

    protected Notification(long targetUserId)
    {
        NotificationId = SnowflakeUtils.GenerateSnowflakeId();
        TargetUserId = targetUserId;
        CreateDate = DateTime.UtcNow;
        IsRead = false;
    }

    public long NotificationId { get; protected set; }

    /// <summary>
    /// 目标用户ID
    /// </summary>
    public long TargetUserId { get; protected set; }

    /// <summary>
    /// 是否已读
    /// </summary>
    public bool IsRead { get; protected set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateDate { get; protected set; }

    public void MarkAsRead()
    {
        IsRead = true;
    }
}