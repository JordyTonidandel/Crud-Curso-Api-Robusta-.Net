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
      optionsBuilder.UseSqlServer(@"Server=tcp:mymanagerapidatabase.database.windows.net,1433;Database=mymanagerapidatabase;User ID=TonidandelAdmin;Password=epUW8MVukPNye6y;Trusted_Connection=False;Encrypt=True;");
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new UserMap());
    }
  }
}
