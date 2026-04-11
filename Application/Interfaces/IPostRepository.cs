using TangyuanBackendASP.Domain.Posts;

namespace TangyuanBackendASP.Application.Interfaces;

public interface IPostRepository
{
    Task<Post?> GetByIdAsync(long postId, CancellationToken cancellationToken);
    Task AddAsync(Post post, CancellationToken cancellationToken);
    Task RemoveAsync(Post post, CancellationToken cancellationToken);
}