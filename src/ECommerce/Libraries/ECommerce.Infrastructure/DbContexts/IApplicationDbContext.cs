using ECommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Inventory> Inventories { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<ReviewImage> ReviewImages { get; set; }
        DbSet<ProductDelete> ProductDeletes { get; set; }
    }
}
