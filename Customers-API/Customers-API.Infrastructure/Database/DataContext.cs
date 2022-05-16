using Customers_API.Core.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Customers_API.Core.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseNpgsql("Erreur");
        }
    }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    public DbSet<CustomerRequest> Customer { get; set; }
    
    public DbSet<OrderRequest> Order { get; set; }
    
    public DbSet<ItemRequest> Item { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
    
}