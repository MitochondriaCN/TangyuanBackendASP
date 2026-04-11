using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Application.Dtos;
using TangyuanBackendASP.Application.Interfaces;

namespace TangyuanBackendASP.Infra.Persistence;

public class PostQueries(TangyuanDbContext db) : IPostQueries
{
    public async Task<PostDto?> GetByIdAsync(long postId, CancellationToken cancellationToken)
    {
        var post = await db.Posts
            .AsNoTracking()
            .Where(post => post.Id == postId)
            .FirstOrDefaultAsync(cancellationToken);

        return post == null
            ? null
            : new PostDto(
                post.Id,
                post.AuthorId,
                post.PublishedAt,
                post.CategoryId,
                post.Body.Value,
                post.IsVisible,
                post.ImageGuids);
    }
}