using BackendForBeginners_Net10_Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendForBeginners_Net10_Solution;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}
