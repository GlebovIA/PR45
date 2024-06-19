using Microsoft.EntityFrameworkCore;
using PR45.Model;
using System;

namespace PR45.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;" +
                "port=3306;" +
                "uid=root;" +
                "pwd=;" +
                "database = TaskManager;",
                new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
