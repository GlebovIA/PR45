using Microsoft.EntityFrameworkCore;
using PR45.Model;

namespace PR45.Context
{
    public class WorkersContext : DbContext
    {
        public DbSet<Workers> Workers { get; set; }
        public WorkersContext()
        {
            Database.EnsureCreated();
            Workers.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Program.ConnectionToMsSqlServer);
    }
}
