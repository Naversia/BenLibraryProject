using BookLib;
using System.Data.Entity;
namespace BenEliLibraryProject
{
    public class LibrayDBContext : DbContext
    {
        //public DbSet<Book> Book { get; set; }
        //public DbSet<Journal> Journal { get; set; }
        public DbSet<AbstractItem> Item { get; set; }
        public LibrayDBContext() : base("name=ModelDB")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
