using MediatR;
using TangyuanBackendASP.Application.Dtos;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Application.Mappers;
using TangyuanBackendASP.Application.Queries;

namespace TangyuanBackendASP.Application.Handlers;

public class GetPostQueryHandler(
    IPostRepository repo) : IRequestHandler<GetPostQuery, PostDto>
{
    public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var post = await repo.GetPostByIdAsync(request.Id);
        return post.ToDto();
    }
}