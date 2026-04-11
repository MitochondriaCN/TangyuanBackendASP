using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Posts;

namespace TangyuanBackendASP.Infra.Persistence;

public class PostRepository(TangyuanDbContext db) : IPostRepository
{
    public Task<Post?> GetByIdAsync(long postId, CancellationToken cancellationToken)
    {
        return db.Posts.FirstOrDefaultAsync(post => post.Id == postId, cancellationToken);
    }

    public async Task AddAsync(Post post, CancellationToken cancellationToken)
    {
        await db.Posts.AddAsync(post, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Post post, CancellationToken cancellationToken)
    {
        db.Posts.Remove(post);
        await db.SaveChangesAsync(cancellationToken);
    }
}