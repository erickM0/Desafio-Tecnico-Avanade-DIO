using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using StockService.Domain.Entities;
using StockService.Domain.Interfaces;


namespace StockService.Infra;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<StockMovement> StockMovements {get; set; }


    public override int SaveChanges()
    {
        OnBeforeSavig();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSavig();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSavig()
    {
        var entries = ChangeTracker.Entries();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {

            if (entry.Entity is IAuditableModified modifiable)
            {
                if (entry.State == EntityState.Added)
                {
                    modifiable.CreatedAt = utcNow;
                    modifiable.LastModifiedAt = utcNow;
                }

                else if (entry.State == EntityState.Modified)
                {
                    modifiable.LastModifiedAt = utcNow;
                }

            }
            else if (entry.Entity is IAuditable auditable && entry.State == EntityState.Added)
            {
                auditable.CreatedAt = utcNow;
            }
            

        }
    }

}
