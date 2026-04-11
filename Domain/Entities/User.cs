using TangyuanBackendASP.Shared.Utils;

namespace TangyuanBackendASP.Domain.Entities;

/// <summary>
/// 用户
/// </summary>
public class User
{
    private User()
    {
    }

    public User(string password, string phoneNumber, string nickname, string isoRegionName)
    {
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("密码不能为空");
        if (string.IsNullOrWhiteSpace(phoneNumber)) throw new ArgumentException("手机号不能为空");

        Id = SnowflakeUtils.GenerateSnowflakeId();
        Password = password;
        PhoneNumber = phoneNumber;
        Nickname = nickname;
        IsoRegionName = isoRegionName;
    }

    public long Id { get; private set; }

    /// <summary>
    /// 密码（Bcrypt）
    /// </summary>
    public string Password { get; private set; } = null!;

    /// <summary>
    /// 昵称
    /// </summary>
    public string Nickname { get; private set; } = null!;

    /// <summary>
    /// 手机号码
    /// </summary>
    public string PhoneNumber { get; private set; } = null!;

    /// <summary>
    /// 用户所在区域，ISO 3166-1二位国家编码，如CN。
    /// </summary>
    public string IsoRegionName { get; private set; } = null!;

    /// <summary>
    /// 用户头像GUID
    /// </summary>
    /// <remarks>在某个具体的存储系统中，应当可以根据这个GUID来获取用户头像。</remarks>
    public string? AvatarGuid { get; private set; }

    /// <summary>
    /// 用户邮箱
    /// </summary>
    public string? Email { get; private set; }

    /// <summary>
    /// 用户个人介绍
    /// </summary>
    public string? Bio { get; private set; }

    public void UpdateNickname(string nickname)
    {
        if (String.IsNullOrWhiteSpace(nickname))
            throw new ArgumentException("昵称不能为空");

        if (nickname.Length > 10)
            throw new ArgumentException("昵称长度不能超过10个字符");

        Nickname = nickname;
    }

    public void UpdateAvatarGuid(string? guid)
    {
        if (string.IsNullOrWhiteSpace(guid))
            throw new ArgumentNullException(nameof(guid));

        AvatarGuid = guid;
    }

    public void UpdateEmail(string? email)
    {
        if (email == null)
        {
            Email = null;
            return;
        }

        if (!StringValidateUtils.IsValidEmail(email))
            throw new ArgumentException("邮箱格式错误", nameof(email));

        Email = email;
    }

    public void UpdateBio(string? bio)
    {
        if (string.IsNullOrWhiteSpace(bio))
            throw new ArgumentNullException(nameof(bio));

        Bio = bio;
    }

    public void UpdatePhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentNullException(nameof(phoneNumber));

        if (!DataValidator.IsPhoneNumberValid(phoneNumber, "CN"))
            throw new ArgumentException("手机号格式错误", nameof(phoneNumber));

        PhoneNumber = phoneNumber;
    }
}