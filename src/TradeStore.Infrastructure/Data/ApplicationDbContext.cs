using Microsoft.EntityFrameworkCore;
using TradeStore.Domain.Entities;

namespace TradeStore.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<ProductType> ProductTypes => Set<ProductType>();
    public DbSet<Location> Locations => Set<Location>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CATEGORY
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.NameCategory)
                .IsRequired()
                .HasMaxLength(100);
        });

        // PRODUCT TYPE
        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.NameType)
                .IsRequired()
                .HasMaxLength(100);
        });

        // LOCATION
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(l => l.Id);

            entity.Property(l => l.NameLocation)
                .IsRequired()
                .HasMaxLength(100);
        });

        // PRODUCT
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.CodTrade).IsRequired();
            entity.Property(p => p.CodNcm).IsRequired();

            entity.Property(p => p.Description).HasMaxLength(255);
            entity.Property(p => p.CodSap).HasMaxLength(100);
            entity.Property(p => p.Notes).HasMaxLength(500);
            entity.Property(p => p.ImgUrl).HasMaxLength(500);

            // RELACIONAMENTO Category (1:N)
            entity.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // RELACIONAMENTO ProductType (1:N)
            entity.HasOne(p => p.Type)
                .WithMany()
                .HasForeignKey(p => p.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // VALUE OBJECT (Dimensions)
            entity.OwnsOne(p => p.Dimensions);

            // RELACIONAMENTO N:N com Location
            entity
                .HasMany(p => p.AllowedLocations)
                .WithMany();
        });
    }
}