using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Infra;

public class TangyuanDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; } = null!;
}