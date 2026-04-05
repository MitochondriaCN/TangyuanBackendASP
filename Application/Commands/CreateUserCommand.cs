using MediatR;

namespace TangyuanBackendASP.Application.Commands;

/// <param name="Password">密码（明文）</param>
public record CreateUserCommand(
    string Password,
    string Nickname,
    string PhoneNumber,
    string IsoRegionName) : IRequest<long>;