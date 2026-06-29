using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApp.Core.Entities;

namespace ShopApp.DataAccess.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");

        builder.Entity<OrderItem>().Property(o => o.UnitPrice).HasColumnType("decimal(18,2)");

        builder.Entity<Order>()
            .Property(o => o.TotalPrice)
            .HasColumnType("decimal(18,2)");
    }
}