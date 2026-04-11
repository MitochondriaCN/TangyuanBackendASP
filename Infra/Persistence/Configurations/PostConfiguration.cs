using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TangyuanBackendASP.Domain.Posts;

namespace TangyuanBackendASP.Infra.Persistence.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");
        builder.HasKey(post => post.Id);

        builder.Property(post => post.Id)
            .HasColumnName("PostId");

        builder.Property(post => post.AuthorId)
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property(post => post.PublishedAt)
            .HasColumnName("PostDateTime")
            .IsRequired();

        builder.Property(post => post.CategoryId)
            .HasColumnName("CategoryId")
            .IsRequired();

        builder.Property(post => post.Body)
            .HasColumnName("TextContent")
            .HasConversion(body => body.Value, value => new PostBody(value))
            .IsRequired();

        builder.Property(post => post.IsVisible)
            .HasColumnName("IsVisible")
            .IsRequired();

        builder.Property(post => post.ImageGuids)
            .HasColumnName("ImageGuids")
            .IsRequired();
    }
}