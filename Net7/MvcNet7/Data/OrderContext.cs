using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcNet7.Models;

namespace MvcNet7.Data
{

    public class OrderContext : IdentityDbContext<ApplicationUser>
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        //- 1 Customer có thể order nhiều order
        //- 1 Order chỉ 1 product
        //  1 Order chỉ thuộc 1 Customer
        //- 1 Product có thể thuộc nhiều Order
        //  1 Product chỉ thuộc 1 Category
        //- 1 Category chỉ thuộc 1 Product

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasKey(p => p.Id);

            modelBuilder.Entity<Order>().HasKey(p => p.Id);
            modelBuilder.Entity<Order>() // One Customer Many  Orders
                .HasOne(c => c.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>() // One Customer Many  Orders
                .HasMany(c => c.Orders)
                .WithOne(e => e.Customer)
                .HasForeignKey(s => s.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Order>().HasKey(p => p.Id);
            //modelBuilder.Entity<Order>() // One Customer Many  Orders
            //    .HasOne(c => c.Customer)
            //    .WithMany(e => e.Orders)
            //    .HasForeignKey(e => e.CustomerId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>() // One Order Many Product
                .HasOne(c => c.Product)
                .WithMany(x => x.Orders)
                .HasForeignKey(e => e.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>().HasKey(p => p.Id); // One Customer One  Category
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithOne(x => x.Product)
                .HasForeignKey<Category>(b => b.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().HasKey(p => p.Id); // 
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Product)
                .WithOne(ad => ad.Category)
                .HasForeignKey<Product>(b => b.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
