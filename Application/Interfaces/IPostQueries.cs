using TangyuanBackendASP.Application.Dtos;

namespace TangyuanBackendASP.Application.Interfaces;

public interface IPostQueries
{
    Task<PostDto?> GetByIdAsync(long postId, CancellationToken cancellationToken);
}