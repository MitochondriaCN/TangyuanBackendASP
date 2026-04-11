using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;

namespace TangyuanBackendASP.Application.Handlers;

public class UpdateUserCommandHandler(IUserRepository repo) : IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repo.GetUserByIdAsync(request.UserId);
        if (user == null)
            return Result.Fail("未找到用户");

        user.UpdateNickname(request.Nickname ?? user.Nickname);
        user.UpdateAvatarGuid(request.AvatarGuid ?? user.AvatarGuid);
        user.UpdateBio(request.Bio ?? user.Bio);
        user.UpdatePhoneNumber(request.PhoneNumber ?? user.PhoneNumber);
        user.UpdateEmail(request.Email ?? user.Email);

        await repo.UpdateUserAsync(user);
        return Result.Ok();
    }
}