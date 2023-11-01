using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class BookContext:DbContext
    {
        public BookContext() 
        {
            
        }
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Book { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-6MK2PS7G;Initial Catalog=Library;Trusted_Connection=True;TrustServerCertificate=True");
        }


    }
}
