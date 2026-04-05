namespace TangyuanBackendASP.Application.Interfaces;

public interface IPasswordEncryptor
{
    string Encrypt(string password);
}