using TangyuanBackendASP.Application.Dtos;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Mappers;

public static class PostMapper
{
    public static PostDto ToDto(this Post post)
    {
        return new PostDto(
            post.PostId,
            post.UserId,
            post.PostDateTime,
            post.CategoryId,
            post.TextContent,
            post.IsVisible,
            post.ImageGuids);
    }
}