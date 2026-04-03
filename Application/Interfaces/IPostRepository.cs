using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Interfaces;

public interface IPostRepository
{
    Task<Post> GetPostByIdAsync(long postId);

    Task<List<Post>> GetPostsByUserIdAsync(long userId);

    Task AddPostAsync(Post post);

    Task DeletePostAsync(long postId);
}