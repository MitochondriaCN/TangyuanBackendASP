using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;

namespace TangyuanBackendASP.Application.Handlers;

public class DeletePostCommandHandler(
    IPostRepository repo) : IRequestHandler<DeletePostCommand, Result>
{
    public async Task<Result> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var post = await repo.GetPostByIdAsync(command.PostId);

        if (post == null)
            return Result.Fail("未找到帖子");

        if (post.UserId != command.UserId)
            return Result.Fail("您不是帖子的作者");

        await repo.DeletePostAsync(command.PostId);
        return Result.Ok();
    }
}