using Microsoft.EntityFrameworkCore;
using PR45.Model;

namespace PR45.Context
{
    public class LiteratureSourcesContext : DbContext
    {
        public DbSet<Literature_sources> Literature_sources { get; set; }
        public LiteratureSourcesContext()
        {
            Database.EnsureCreated();
            Literature_sources.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Program.ConnectionToMsSqlServer);
    }
}
