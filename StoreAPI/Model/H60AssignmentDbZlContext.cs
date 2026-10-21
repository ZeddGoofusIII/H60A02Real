using System;
using System.Collections.Generic;
using A01.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreAPI.Model;

public partial class H60AssignmentDbZlContext : DbContext
{
    public H60AssignmentDbZlContext()
    {
    }

    public H60AssignmentDbZlContext(DbContextOptions<H60AssignmentDbZlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:csdevdb-heritagecs.database.windows.net,1433; Database=H60_AssignmentDB_ZL;Authentication=Active Directory Interactive; Encrypt=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductCategoryId, "IX_Product_ProductCategoryId");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.BuyPrice).HasColumnType("numeric(8, 2)");
            entity.Property(e => e.Description)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.SellPrice).HasColumnType("numeric(8, 2)");

            entity.HasOne(d => d.ProdCat).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId);

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryId");
            entity.Property(e => e.ProdCat)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.HasIndex(e => e.CustomerId, "X_Customer_CustomerId");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
            entity.Property(e => e.Firstname).HasColumnType("varchar(20)");
            entity.Property(e => e.Lastname).HasColumnType("varchar(30)");
            entity.Property(e => e.Email).HasColumnType("varchar(30)");
            entity.Property(e => e.PhoneNumber).HasColumnType("varchar(10)");
            entity.Property(e => e.Province).HasColumnType("varchar(2)");
            entity.Property(e => e.CreditCard).HasColumnType("varchar(16)");

            entity.HasData(new Customer { Firstname = "Cassius", Lastname = "Bright", CreditCard = "456789123789546", Email="example@example.com", PhoneNumber="9874566123", CustomerId = 1 },
                new Customer { Firstname = "Guy", Lastname = "Ofsomekind", CreditCard = "456989123789546", Email = "letme@example.com", PhoneNumber = "9874786123", CustomerId = 2 },
                new Customer { Firstname = "Olivier", Lastname = "Laurence", CreditCard = "786989123789546", Email = "Liyrest@example.com", PhoneNumber = "9879986123", CustomerId = 3 });
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {

            entity.HasKey(e => e.CartId);
            entity.ToTable("ShoppingCart");

            entity.Property(e => e.CartId).HasColumnType("int");
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.HasOne(e => e.Customer).WithOne(p => p.ShoppingCart);
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId);

            entity.ToTable("CartItem");

            entity.Property(e => e.CartItemId).HasColumnType("int");
            entity.Property(e => e.Quantity).HasColumnType("int");
            entity.Property(e => e.Price).HasColumnType("numeric(8,2)");
            entity.Property(e => e.CartId).HasColumnType("int");
            entity.Property(e =>e.ProductId).HasColumnType("int");
            entity.HasOne(p => p.Product);

        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnType("int");
            entity.Property(e => e.CustomerId).HasColumnType("int");
            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.DateFulfilled).HasColumnType("date");
            entity.Property(e => e.Total).HasColumnType("numeric(10,2)");
            entity.Property(e => e.taxes).HasColumnType("numeric(8,2)");
            entity.HasOne(e => e.Customer).WithMany(c => c.Orders).HasForeignKey(p => p.CustomerId);

            entity.HasData(new Order { CustomerId = 1, OrderId = 1, DateCreated = new DateOnly(2026, 06, 03), DateFulfilled = new DateOnly(2026, 06, 16), taxes=10, Total=100});
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);
            entity.ToTable("OrderItem");

            entity.Property(e => e.OrderItemId).HasColumnType("int");
            entity.Property(e => e.OrderId).HasColumnType("int");
            entity.Property(e => e.ProductId).HasColumnType("int");
            entity.Property(e => e.Quantity).HasColumnType("int");
            entity.Property(e => e.Price).HasColumnType("numeric(8,2)");

            entity.HasOne(p => p.Product);
            entity.HasOne(p => p.Order).WithMany(o => o.OrderItems).HasForeignKey(p => p.OrderId);

            entity.HasData(new OrderItem { OrderItemId = 1, ProductId = 1, OrderId = 1, Price = 1, Quantity = 1 },
                new OrderItem { OrderItemId = 2, ProductId = 1, OrderId = 1, Price = 1, Quantity = 1 },
                new OrderItem { OrderItemId = 3, ProductId = 1, OrderId = 1, Price = 1, Quantity = 1 });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
