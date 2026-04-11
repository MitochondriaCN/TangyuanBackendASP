using TangyuanBackendASP.Domain.Users;

namespace TangyuanBackendASP.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(long userId, CancellationToken cancellationToken);
    Task<bool> ExistsByPhoneNumberAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}