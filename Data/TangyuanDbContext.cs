using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Data
{
    public class TangyuanDbContext : DbContext
    {
        public TangyuanDbContext(DbContextOptions<TangyuanDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PostMetadata> PostMetadata { get; set; } = null;
        public DbSet<User> User { get; set; } = null;
        public DbSet<PostBody> PostBody { get; set; } = null;
        public DbSet<Comment> Comment { get; set; } = null;
        public DbSet<Notification> Notification { get; set; } = null;
        public DbSet<Category> Category { get; set; } = null;
        public DbSet<NewNotification> NewNotification { get; set; } = null;

        public DbSet<Follow> Follow { get; set; } = null;
    }
}
