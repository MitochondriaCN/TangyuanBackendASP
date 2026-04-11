using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Common;
using TangyuanBackendASP.Domain.Users;

namespace TangyuanBackendASP.Application.Handlers;

public class UpdateUserCommandHandler(IUserRepository repo) : IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repo.GetByIdAsync(request.UserId, cancellationToken);
        if (user == null)
            return Result.Fail("未找到用户");

        try
        {
            if (request.Nickname is not null)
                user.ChangeNickname(new Nickname(request.Nickname));

            if (request.AvatarGuid is not null)
                user.ChangeAvatar(request.AvatarGuid);

            if (request.Bio is not null)
                user.ChangeBio(request.Bio);

            if (request.PhoneNumber is not null)
            {
                var newPhoneNumber = new PhoneNumber(request.PhoneNumber, user.IsoRegionCode);
                if (newPhoneNumber != user.PhoneNumber &&
                    await repo.ExistsByPhoneNumberAsync(newPhoneNumber, cancellationToken))
                {
                    return Result.Fail("手机号已存在");
                }

                user.ChangePhoneNumber(newPhoneNumber);
            }

            if (request.Email is not null)
                user.ChangeEmail(new EmailAddress(request.Email));

            await repo.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
        catch (DomainException ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}