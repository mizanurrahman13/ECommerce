using ECommerce.Infrastructure.Entities.Membership;

namespace ECommerce.Infrastructure.Seeds
{
    public static class RoleSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role { Id = Guid.Parse("B08643FD-487F-401C-97BB-6117531ABC7A"), 
                        Name = "Admin", NormalizedName = "ADMIN", 
                        ConcurrencyStamp = DateTime.Now.Ticks.ToString(),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    }
                };
            }
        }
    }
}
