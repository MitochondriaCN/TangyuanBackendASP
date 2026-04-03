using MediatR;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Application.Posts.Dtos;
using TangyuanBackendASP.Application.Posts.Mappers;
using TangyuanBackendASP.Application.Posts.Queries;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Posts.Handlers;

public class GetPostHandler(
    IPostRepository repo) : IRequestHandler<GetPostQuery, PostDto>
{
    public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var post = await repo.GetPostByIdAsync(request.Id);
        return post.ToDto();
    }
}