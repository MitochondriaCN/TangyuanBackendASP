using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Application.Interfaces;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Infra.Persistence;

public class UserRepository(TangyuanDbContext db) : IUserRepository
{
    public Task<User?> GetUserByIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckPhoneNumberExistsAsync(string phoneNumber)
    {
        return db.Users.AnyAsync(u => u.PhoneNumber == phoneNumber);
    }

    public Task<List<User>> SearchUserByNicknameAsync(string nickname)
    {
        throw new NotImplementedException();
    }

    public Task AddUserAsync(User user)
    {
        db.Users.Add(user);
        return db.SaveChangesAsync();
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(long userId)
    {
        throw new NotImplementedException();
    }
}