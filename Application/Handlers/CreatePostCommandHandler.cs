using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Handlers;

public class CreatePostCommandHandler(
    IPostRepository repo) : IRequestHandler<CreatePostCommand, long>
{
    public async Task<long> Handle(CreatePostCommand command, CancellationToken cancellationToken)
    {
        var post = new Post(
            command.UserId,
            command.TextContent,
            command.CategoryId,
            command.PostDateTime,
            command.ImageGuids);
        await repo.AddPostAsync(post);
        return post.PostId;
    }
}