using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PW_Assignment_3.Models
{
    public partial class Site_DBContext : DbContext
    {
        public Site_DBContext()
        {
        }

        public Site_DBContext(DbContextOptions<Site_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesProd> SalesProds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ConnectionStrings: BSConn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK_Dept");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("deptId");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("deptName");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.employeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employeeId");

                entity.Property(e => e.city)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.deptId).HasColumnName("deptId");

                entity.Property(e => e.firstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.lastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ProductName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId)
                    .ValueGeneratedNever()
                    .HasColumnName("saleId");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("date")
                    .HasColumnName("saleDate");

                entity.Property(e => e.Total)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("total");
            });

            modelBuilder.Entity<SalesProd>(entity =>
            {
                entity.HasKey(e => new { e.SaleId, e.ProductId });

                entity.ToTable("SalesProd");

                entity.Property(e => e.SaleId).HasColumnName("saleId");

                entity.Property(e => e.ProductId).HasColumnName("productId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}