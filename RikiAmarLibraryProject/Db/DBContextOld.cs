using BookLib;
using System.Data.Entity;

namespace BenEliLibraryProject.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<Book> MyModels { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connection_string_here");
        //}
    }
}