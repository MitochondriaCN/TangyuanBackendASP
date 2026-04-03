using MediatR;
using TangyuanBackendASP.Application.Dtos;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Application.Mappers;
using TangyuanBackendASP.Application.Queries;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Handlers;

public class GetPostHandler(
    IPostRepository repo) : IRequestHandler<GetPostQuery, PostDto>
{
    public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var post = await repo.GetPostByIdAsync(request.Id);
        return post.ToDto();
    }
}