using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Domain.Posts;
using TangyuanBackendASP.Domain.Users;

namespace TangyuanBackendASP.Infra;

public class TangyuanDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TangyuanDbContext).Assembly);
    }
}