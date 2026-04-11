using FluentResults;
using MediatR;

namespace TangyuanBackendASP.Application.Commands;

public record DeletePostCommand(
    long PostId,
    long UserId
) : IRequest<Result>;