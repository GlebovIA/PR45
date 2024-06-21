using Microsoft.EntityFrameworkCore;
using PR45.Model;

namespace PR45.Context
{
    public class LiteratureTypesContext : DbContext
    {
        public DbSet<Literature_types> Literature_types { get; set; }
        public LiteratureTypesContext()
        {
            Database.EnsureCreated();
            Literature_types.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(Program.ConnectionToMsSqlServer);
    }
}
