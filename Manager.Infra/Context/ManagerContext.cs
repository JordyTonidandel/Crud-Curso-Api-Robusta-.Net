using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context
{
  public class ManagerContext : DbContext
  {
    public ManagerContext() { }

    public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=USER_MANAGER_API;Integrated Security=True;");
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new UserMap());
    }
  }
}
