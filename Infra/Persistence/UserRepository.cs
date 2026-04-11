using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Users;

namespace TangyuanBackendASP.Infra.Persistence;

public class UserRepository(TangyuanDbContext db) : IUserRepository
{
    public Task<User?> GetByIdAsync(long userId, CancellationToken cancellationToken)
    {
        return db.Users.FirstOrDefaultAsync(user => user.Id == userId, cancellationToken);
    }

    public Task<bool> ExistsByPhoneNumberAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken)
    {
        return db.Users.AnyAsync(user => user.PhoneNumber == phoneNumber, cancellationToken);
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await db.Users.AddAsync(user, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return db.SaveChangesAsync(cancellationToken);
    }
}