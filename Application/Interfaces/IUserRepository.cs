using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(long userId);

    Task<bool> CheckPhoneNumberExistsAsync(string phoneNumber);

    Task<List<User>> SearchUserByNicknameAsync(string nickname);

    Task AddUserAsync(User user);

    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(long userId);
}