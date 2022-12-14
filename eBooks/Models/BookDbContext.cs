using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//The DBcontext file
namespace eBooks.Models
{
    public class BookDbContext:IdentityDbContext<ApplicationUser>
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().HasKey(am => new
            {
                am.AuthorID,
                am.BookID
            });

            modelBuilder.Entity<Author_Book>().HasOne(m => m.Author).WithMany(am => am.Author_Books).HasForeignKey(m => m.AuthorID);
            modelBuilder.Entity<Author_Book>().HasOne(m => m.Book).WithMany(am => am.Author_Books).HasForeignKey(m => m.BookID); 


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }


    }
}
