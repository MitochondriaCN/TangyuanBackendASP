using Microsoft.EntityFrameworkCore;
using TangyuanBackendASP.Domain.Entities;

namespace TangyuanBackendASP.Infra;

public class TangyuanDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
}