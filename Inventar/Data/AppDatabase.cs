using Inventar.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Data
{
    public class AppDatabase : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        private string dbPath;

        public AppDatabase(string dbPath)
        {
            this.dbPath = dbPath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}