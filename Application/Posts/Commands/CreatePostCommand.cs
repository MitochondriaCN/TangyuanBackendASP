using MediatR;

namespace TangyuanBackendASP.Application.Posts.Commands;

public record CreatePostCommand(
    long UserId,
    DateTime PostDateTime,
    long CategoryId,
    string TextContent,
    params string[] ImageGuids
) : IRequest<long>;