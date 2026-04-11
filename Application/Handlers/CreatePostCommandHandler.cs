using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Common;
using TangyuanBackendASP.Domain.Posts;

namespace TangyuanBackendASP.Application.Handlers;

public class CreatePostCommandHandler(
    IPostRepository repo,
    IIdGenerator idGenerator) : IRequestHandler<CreatePostCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var post = Post.Create(
                idGenerator.NextId(),
                command.UserId,
                command.CategoryId,
                DateTime.UtcNow,
                new PostBody(command.TextContent),
                command.ImageGuids);

            await repo.AddAsync(post, cancellationToken);
            return Result.Ok(post.Id);
        }
        catch (DomainException ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}