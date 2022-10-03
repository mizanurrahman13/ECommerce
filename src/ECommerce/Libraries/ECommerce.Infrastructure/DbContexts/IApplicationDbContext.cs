using ECommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
    }
}
