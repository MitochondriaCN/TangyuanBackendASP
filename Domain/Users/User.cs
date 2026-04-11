using TangyuanBackendASP.Domain.Common;

namespace TangyuanBackendASP.Domain.Users;

public class User
{
    private User()
    {
    }

    private User(long id, string passwordHash, PhoneNumber phoneNumber, Nickname nickname, IsoRegionCode regionCode)
    {
        if (id <= 0)
            throw new DomainException("用户ID非法");
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new DomainException("密码不能为空");

        Id = id;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Nickname = nickname;
        IsoRegionCode = regionCode;
    }

    public long Id { get; private set; }

    public string PasswordHash { get; private set; } = null!;

    public Nickname Nickname { get; private set; } = null!;

    public PhoneNumber PhoneNumber { get; private set; } = null!;

    public IsoRegionCode IsoRegionCode { get; private set; } = null!;

    public string? AvatarGuid { get; private set; }

    public EmailAddress? Email { get; private set; }

    public string? Bio { get; private set; }

    public static User Register(
        long id,
        string passwordHash,
        PhoneNumber phoneNumber,
        Nickname nickname,
        IsoRegionCode regionCode)
    {
        return new User(id, passwordHash, phoneNumber, nickname, regionCode);
    }

    public void ChangeNickname(Nickname nickname)
    {
        Nickname = nickname;
    }

    public void ChangeAvatar(string avatarGuid)
    {
        if (string.IsNullOrWhiteSpace(avatarGuid))
            throw new DomainException("头像GUID不能为空");
        if (!Guid.TryParse(avatarGuid.Trim(), out _))
            throw new DomainException("头像GUID格式错误");

        AvatarGuid = avatarGuid.Trim();
    }

    public void ChangeBio(string bio)
    {
        if (string.IsNullOrWhiteSpace(bio))
            throw new DomainException("个人介绍不能为空");

        Bio = bio.Trim();
    }

    public void ChangePhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void ChangeEmail(EmailAddress email)
    {
        Email = email;
    }
}