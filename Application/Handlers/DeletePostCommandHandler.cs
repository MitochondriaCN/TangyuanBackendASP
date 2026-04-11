using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Application.Handlers;

public class DeletePostCommandHandler(
    IPostRepository repo) : IRequestHandler<DeletePostCommand, Result>
{
    public async Task<Result> Handle(DeletePostCommand command, CancellationToken cancellationToken)
    {
        var post = await repo.GetByIdAsync(command.PostId, cancellationToken);

        if (post == null)
            return Result.Fail("未找到帖子");

        try
        {
            post.EnsureAuthoredBy(command.UserId);
            await repo.RemoveAsync(post, cancellationToken);
            return Result.Ok();
        }
        catch (DomainException ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}