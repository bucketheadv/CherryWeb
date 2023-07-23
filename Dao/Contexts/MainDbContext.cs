using Microsoft.EntityFrameworkCore;
using CherryWeb.Models;

namespace CherryWeb.Dao.Contexts {
    public class MainDbContext : DbContext {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        public DbSet<User>? User { get; set; }
    }
}