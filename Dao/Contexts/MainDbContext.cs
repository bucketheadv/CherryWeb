using Microsoft.EntityFrameworkCore;
using CherryWeb.Models;

namespace CherryWeb.Dao.Contexts;

public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
{
    public DbSet<User>? User { get; set; }
}