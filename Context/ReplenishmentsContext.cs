using Microsoft.EntityFrameworkCore;
using PR45.Model;

namespace PR45.Context
{
    public class ReplenishmentsContext : DbContext
    {
        public DbSet<Replenishments> Replenishments { get; set; }
        public ReplenishmentsContext()
        {
            Database.EnsureCreated();
            Replenishments.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Program.ConnectionToMsSqlServer);
    }
}
