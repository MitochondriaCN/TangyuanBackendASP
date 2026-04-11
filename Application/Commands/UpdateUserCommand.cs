using FluentResults;
using MediatR;

namespace TangyuanBackendASP.Application.Commands;

public record UpdateUserCommand(
    long UserId,
    string? Nickname = null,
    string? PhoneNumber = null,
    string? AvatarGuid = null,
    string? Bio = null,
    string? Email = null
) : IRequest<Result>;