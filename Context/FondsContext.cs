using Microsoft.EntityFrameworkCore;
using PR45.Model;

namespace PR45.Context
{
    public class FondsContext : DbContext
    {
        public DbSet<Fonds> Fonds { get; set; }
        public FondsContext()
        {
            Database.EnsureCreated();
            Fonds.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Program.ConnectionToMsSqlServer);
    }
}
