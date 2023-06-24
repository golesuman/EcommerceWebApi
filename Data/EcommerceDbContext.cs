using Microsoft.EntityFrameworkCore;
using EcommerceWebApi.Model;

namespace EcommerceWebApi.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts {get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, constraints, and other configurations using modelBuilder.Entity<T>().
            // For example:
            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.User)
            //     .WithMany(u => u.Orders)
            //     .HasForeignKey(o => o.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<EcommerceWebApi.Model.Cart> Cart { get; set; } = default!;
    }
}