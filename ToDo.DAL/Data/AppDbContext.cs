using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entity;

namespace ToDo.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserTask> UserTask { get; set; }
    }
}
