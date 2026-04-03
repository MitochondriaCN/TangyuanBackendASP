using MediatR;

namespace TangyuanBackendASP.Application.Commands;

public record CreatePostCommand(
    long UserId,
    DateTime PostDateTime,
    long CategoryId,
    string TextContent,
    params string[] ImageGuids
) : IRequest<long>;