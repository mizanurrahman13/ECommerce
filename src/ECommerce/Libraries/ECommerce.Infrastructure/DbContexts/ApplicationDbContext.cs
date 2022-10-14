using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ECommerce.Infrastructure.Entities.Membership;
using ECommerce.Infrastructure.Seeds;
using ECommerce.Infrastructure.Entities;
using System.Reflection.Emit;

namespace ECommerce.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid,
        UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
            )
            : base(options)
        {
        }

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IAuditable entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.UpdatedDate = now;
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                            entity.UpdatedDate = now;
                            break;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Composit key(prodcut and category)
            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });

            //ProductCategory(one)--product(many)
            modelBuilder.Entity<ProductCategory>()
                .HasOne<Product>(p => p.Product)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(f => f.ProductId);

            //ProductCategory(one)--category(many)
            modelBuilder.Entity<ProductCategory>()
                .HasOne<Category>(c => c.Category)
                .WithMany(pc => pc.ProductCategories)
                .HasForeignKey(f => f.CategoryId);

            //ProductImage to Product one to many realtionship
            modelBuilder.Entity<Product>()
                .HasMany<ProductImage>(pi => pi.ProductImages)
                .WithOne(p => p.Product)
                .HasForeignKey(f => f.ProductId);

            //product to inventory one to one relationship
            modelBuilder.Entity<Product>()
                .HasOne<Inventory>(pi => pi.ProductInventory)
                .WithOne(p => p.Product)
                .HasForeignKey<Inventory>(f => f.ProductId);

            //Product to Review one to many realtionship
            modelBuilder.Entity<Product>()
                .HasMany<Review>(r => r.Reviews)
                .WithOne(p => p.Product)
                .HasForeignKey(f => f.ProductId);

            //Review to ReviewImage one to many realtionship
            modelBuilder.Entity<Review>()
                .HasMany<ReviewImage>(ri => ri.ReviewImages)
                .WithOne(r => r.Review)
                .HasForeignKey(f => f.ReviewId);

            modelBuilder.Entity<Role>()
                .HasData(RoleSeed.Roles);

            modelBuilder.Entity<Category>()
                .HasData(CategorySeed.Categories);

            modelBuilder.Entity<Product>()
                .HasData(ProductSeed.Products);

            modelBuilder.Entity<Inventory>()
                .HasData(InventorySeed.Inventories);

            modelBuilder.Entity<ProductImage>()
                .HasData(ProductImageSeed.ProductImages);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }
        public DbSet<ProductDelete> ProductDeletes { get; set; }
    }
}
