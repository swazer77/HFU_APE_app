using Microsoft.EntityFrameworkCore;
using MovieInventoryApp.Models;

namespace MovieInventoryApp.Data
{
    public class AppDatabase : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        private string _dbPath;

        public AppDatabase(string dbPath)
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }
    }
}