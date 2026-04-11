using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Handlers;

public class CreateUserCommandHandler(
    IUserRepository repo,
    IPasswordEncryptor encryptor) : IRequestHandler<CreateUserCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var phoneNumberExists = await repo.CheckPhoneNumberExistsAsync(request.PhoneNumber);
        if (phoneNumberExists)
        {
            return Result.Fail("手机号已存在");
        }

        var user = new User(
            password: encryptor.Encrypt(request.Password),
            phoneNumber: request.PhoneNumber,
            nickname: request.Nickname,
            isoRegionName: request.IsoRegionName);

        await repo.AddUserAsync(user);
        return Result.Ok(user.Id);
    }
}