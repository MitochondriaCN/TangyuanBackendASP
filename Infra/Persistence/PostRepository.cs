using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Infra.Persistence;

public class PostRepository(TangyuanDbContext db) : IPostRepository
{
    public async Task<Post?> GetPostByIdAsync(long postId)
    {
        return await db.Posts.FirstOrDefaultAsync(p => p.PostId == postId) ?? null!;
    }

    public Task<List<Post>> GetPostsByUserIdAsync(long userId)
    {
        return db.Posts.Where(p => p.UserId == userId).ToListAsync();
    }

    public Task AddPostAsync(Post post)
    {
        db.Posts.Add(post);
        return db.SaveChangesAsync();
    }

    public async Task DeletePostAsync(long postId)
    {
        var post = await db.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
        if (post is null)
        {
            return;
        }

        db.Posts.Remove(post);
        await db.SaveChangesAsync();
    }
}