using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TangyuanBackendASP.Domain.Users;

namespace TangyuanBackendASP.Infra.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(user => user.Id);

        builder.Property(user => user.PasswordHash)
            .HasColumnName("Password")
            .IsRequired();

        builder.Property(user => user.Nickname)
            .HasColumnName("Nickname")
            .HasConversion(nickname => nickname.Value, value => new Nickname(value))
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(user => user.PhoneNumber)
            .HasColumnName("PhoneNumber")
            .HasConversion(phoneNumber => phoneNumber.Value, value => PhoneNumber.Restore(value))
            .IsRequired();

        builder.Property(user => user.IsoRegionCode)
            .HasColumnName("IsoRegionName")
            .HasConversion(regionCode => regionCode.Value, value => new IsoRegionCode(value))
            .HasMaxLength(2)
            .IsRequired();

        builder.Property(user => user.Email)
            .HasColumnName("Email")
            .HasConversion(
                email => email == null ? null : email.Value,
                value => string.IsNullOrWhiteSpace(value) ? null : new EmailAddress(value));

        builder.Property(user => user.AvatarGuid)
            .HasColumnName("AvatarGuid")
            .HasMaxLength(36);

        builder.Property(user => user.Bio)
            .HasColumnName("Bio");
    }
}