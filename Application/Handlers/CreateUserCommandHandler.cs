using MediatR;
using TangyuanBackendASP.Application.Commands;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Handlers;

public class CreateUserCommandHandler(
    IUserRepository repo,
    IPasswordEncryptor encryptor) : IRequestHandler<CreateUserCommand, long>
{
    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var phoneNumberExists = await repo.CheckPhoneNumberExistsAsync(request.PhoneNumber);
        if (phoneNumberExists)
        {
            throw new ArgumentException("手机号已存在");
        }

        var user = new User(
            password: encryptor.Encrypt(request.Password),
            phoneNumber: request.PhoneNumber,
            nickName: request.Nickname,
            isoRegionName: request.IsoRegionName);

        await repo.AddUserAsync(user);
        return user.Id;
    }
}