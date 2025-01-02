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

        public DbSet<Order>? Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create unique index for email
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Email)
                .IsUnique();
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Orders)
                .WithOne(o => o.Account)
                .HasForeignKey(o => o.AccountId);
        }
    }
   
}
