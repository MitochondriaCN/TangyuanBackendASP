using TangyuanBackendASP.Application.Interfaces;

namespace TangyuanBackendASP.Infra.Services;

public class BcryptPasswordEncryptor : IPasswordEncryptor
{
    public string Encrypt(string password)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(password);
        return hash;
    }
}