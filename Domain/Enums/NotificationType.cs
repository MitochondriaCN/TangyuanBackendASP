namespace TangyuanBackendASP.Domain.Enums;

public enum NotificationType
{
    /// <summary>
    /// 帖子被评论
    /// </summary>
    Commented,

    /// <summary>
    /// 评论被回复
    /// </summary>
    Replied,

    /// <summary>
    /// 被关注
    /// </summary>
    Followed,

    /// <summary>
    /// 被提及
    /// </summary>
    Mentioned,

    /// <summary>
    /// 一般通知
    /// </summary>
    Notice
}