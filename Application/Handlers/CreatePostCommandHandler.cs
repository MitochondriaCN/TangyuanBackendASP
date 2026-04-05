using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Handlers;

public class CreatePostCommandHandler(
    IPostRepository repo) : IRequestHandler<CreatePostCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var post = new Post(
            command.UserId,
            command.TextContent,
            command.CategoryId,
            command.PostDateTime,
            command.ImageGuids);
        await repo.AddPostAsync(post);
        return Result.Ok(post.PostId);
    }
}