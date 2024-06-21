using Microsoft.EntityFrameworkCore;
using PR45.Model;

namespace PR45.Context
{
    public class LibrariesContext : DbContext
    {
        public DbSet<Libraries> Libraries { get; set; }
        public LibrariesContext()
        {
            Database.EnsureCreated();
            Libraries.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Program.ConnectionToMsSqlServer);
    }
}
