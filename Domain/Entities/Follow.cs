using Microsoft.EntityFrameworkCore;

namespace TangyuanBackendASP.Domain.Entities;

/// <summary>
/// 关注关系
/// </summary>
public class Follow
{
    private Follow()
    {
    }

    public Follow(long srcUserId, long targetUserId)
    {
        SourceUserId = srcUserId;
        TargetUserId = targetUserId;
        FollowedAt = DateTime.UtcNow;
    }

    public long SourceUserId { get; private set; }
    public long TargetUserId { get; private set; }
    public DateTime FollowedAt { get; private set; }
}