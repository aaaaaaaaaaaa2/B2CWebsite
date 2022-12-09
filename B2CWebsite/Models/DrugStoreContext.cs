using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace B2CWebsite.Models;

public partial class DrugStoreContext : DbContext
{
    public DrugStoreContext()
    {
    }

    public DrugStoreContext(DbContextOptions<DrugStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Supplement> Supplements { get; set; }

    public virtual DbSet<TransactStatus> TransactStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=MY-ONLY-REASON\\SQLEXPRESS;Initial Catalog=DrugStore;Persist Security Info=True;User ID=sa;Password=1;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__349DA586F32C672E");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("AccountID");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasColumnType("text");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)

                .HasConstraintName("FK_Accounts_Customers");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Accounts__RoleID__49C3F6B7");
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PK__Agent__9AC3BFD1C35B1515");

            entity.ToTable("Agent");

            entity.Property(e => e.AgentId)
                .ValueGeneratedNever()
                .HasColumnName("AgentID");
            entity.Property(e => e.AgentAddress).HasColumnType("text");
            entity.Property(e => e.AgentEmail).HasColumnType("text");
            entity.Property(e => e.AgentName).HasColumnType("text");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Category__6A1C8ADA87E24470");

            entity.ToTable("Category");

            entity.Property(e => e.CatId)
                .ValueGeneratedNever()
                .HasColumnName("CatID");
            entity.Property(e => e.CatName).HasColumnType("text");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Thumb).HasColumnType("text");
            entity.Property(e => e.Title).HasColumnType("text");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8DB55DEEF");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasColumnType("text");
            entity.Property(e => e.Password).HasColumnType("text");
            entity.Property(e => e.Phone)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManuId).HasName("PK__Manufact__4135BFA56496A086");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.ManuId)
                .ValueGeneratedNever()
                .HasColumnName("ManuID");
            entity.Property(e => e.ManuAddress).HasColumnType("text");
            entity.Property(e => e.ManuCountry).HasColumnType("text");
            entity.Property(e => e.ManuEmail).HasColumnType("text");
            entity.Property(e => e.ManuName).HasColumnType("text");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFADC07772");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Note).HasColumnType("text");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.TransactId).HasColumnName("TransactID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__403A8C7D");

            entity.HasOne(d => d.Transact).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TransactId)
                .HasConstraintName("FK__Orders__Transact__412EB0B6");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C8A92814B");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShipDate).HasColumnType("datetime");
            entity.Property(e => e.Sid).HasColumnName("SID");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__5FB337D6");

            entity.HasOne(d => d.SidNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Sid)
                .HasConstraintName("FK__OrderDetail__SID__60A75C0F");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PK__Pages__C565B124DEBCD68C");

            entity.Property(e => e.PageId)
                .ValueGeneratedNever()
                .HasColumnName("PageID");
            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.Contents).HasColumnType("text");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.MetaDesc).HasMaxLength(250);
            entity.Property(e => e.MetaKey).HasMaxLength(250);
            entity.Property(e => e.PageName).HasColumnType("text");
            entity.Property(e => e.Thumb).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3ADFFAD443");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplement>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Suppleme__CA1959701EC1FCBA");

            entity.ToTable("Supplement");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("SID");
            entity.Property(e => e.CatId).HasColumnName("CatID");
            entity.Property(e => e.Directions).HasColumnType("text");
            entity.Property(e => e.InactiveIngredient).HasColumnType("text");
            entity.Property(e => e.Ingredient).HasColumnType("text");
            entity.Property(e => e.ManuId).HasColumnName("ManuID");
            entity.Property(e => e.OtherInfo).HasColumnType("text");
            entity.Property(e => e.Slink)
                .HasColumnType("text")
                .HasColumnName("SLink");
            entity.Property(e => e.Sname)
                .HasColumnType("text")
                .HasColumnName("SName");
            entity.Property(e => e.Uses).HasColumnType("text");
            entity.Property(e => e.Warnings).HasColumnType("text");

            entity.HasOne(d => d.Cat).WithMany(p => p.Supplements)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__Supplemen__CatID__59FA5E80");

            entity.HasOne(d => d.Manu).WithMany(p => p.Supplements)
                .HasForeignKey(d => d.ManuId)
                .HasConstraintName("FK__Supplemen__ManuI__59063A47");
        });

        modelBuilder.Entity<TransactStatus>(entity =>
        {
            entity.HasKey(e => e.TransactId).HasName("PK__Transact__4400DE75A0475FE7");

            entity.ToTable("TransactStatus");

            entity.Property(e => e.TransactId)
                .ValueGeneratedNever()
                .HasColumnName("TransactID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
