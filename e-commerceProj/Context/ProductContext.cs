
using e_commerceProj.Models;
using Microsoft.EntityFrameworkCore;
namespace e_commerceProj.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartID, cp.ProductID });

            modelBuilder.Entity<Product>()
                .HasKey(cp => cp.ProductID);

            modelBuilder.Entity<Cart>()
                .HasKey(cp => cp.CartID);



            modelBuilder.Entity<CartProduct>()
            .HasOne(p => p.Product)
            .WithMany(c => c.CartProducts)
            .HasForeignKey(p => p.ProductID);


            modelBuilder.Entity<CartProduct>()
            .HasOne(p => p.Cart)
            .WithMany(c => c.CartProducts)
            .HasForeignKey(p => p.CartID);

        }
    }
}