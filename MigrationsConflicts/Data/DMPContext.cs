using Microsoft.EntityFrameworkCore;
using MigrationsConflicts.Models;

namespace MigrationsConflicts.Data
{
  public class DMPContext:DbContext
  {
    public DMPContext(DbContextOptions<DMPContext> options) : base(options)
    {
    }
    public DbSet<IOTAsset> IOTAssets { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
