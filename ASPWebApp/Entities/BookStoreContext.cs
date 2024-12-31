using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Entities
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<Book>? Books { get; set; }

        public DbSet<Account>? Accounts { get; set; }
    }
   
}
