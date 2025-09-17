using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models; 
namespace P02_SalesDatabase.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = localhost; Database = P02_SalesDatabase; User ID=sa; Password=DB_Password; TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Product
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsUnicode(true);

        // Customer
        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsUnicode(true);

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .HasMaxLength(80)
            .IsUnicode(false);

        // Store
        modelBuilder.Entity<Store>()
            .Property(s => s.Name)
            .HasMaxLength(80)
            .IsUnicode(true);
    }
}