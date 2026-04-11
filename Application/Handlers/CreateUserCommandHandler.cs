using FluentResults;
using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Common;
using TangyuanBackendASP.Domain.Users;

namespace TangyuanBackendASP.Application.Handlers;

public class CreateUserCommandHandler(
    IUserRepository repo,
    IPasswordEncryptor encryptor,
    IIdGenerator idGenerator) : IRequestHandler<CreateUserCommand, Result<long>>
{
    public async Task<Result<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var regionCode = new IsoRegionCode(request.IsoRegionName);
            var phoneNumber = new PhoneNumber(request.PhoneNumber, regionCode);

            if (await repo.ExistsByPhoneNumberAsync(phoneNumber, cancellationToken))
                return Result.Fail("手机号已存在");

            var user = User.Register(
                id: idGenerator.NextId(),
                passwordHash: encryptor.Encrypt(request.Password),
                phoneNumber: phoneNumber,
                nickname: new Nickname(request.Nickname),
                regionCode: regionCode);

            await repo.AddAsync(user, cancellationToken);
            return Result.Ok(user.Id);
        }
        catch (DomainException ex)
        {
            return Result.Fail(ex.Message);
        }
    }
}