using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Infra.Persistence;

public class PostRepository(TangyuanDbContext db) : IPostRepository
{
    public Task<Post> GetPostByIdAsync(long postId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Post>> GetPostsByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddPostAsync(Post post)
    {
        db.Posts.Add(post);
        return db.SaveChangesAsync();
    }

    public Task DeletePostAsync(long postId)
    {
        throw new NotImplementedException();
    }
}