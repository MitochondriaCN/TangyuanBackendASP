using FluentResults;
using MediatR;

namespace TangyuanBackendASP.Application.Commands;

public record CreatePostCommand(
    long UserId,
    long CategoryId,
    string TextContent,
    params string[] ImageGuids
) : IRequest<Result<long>>;