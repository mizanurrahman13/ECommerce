using ECommerce.Infrastructure.Entities.Membership;

namespace ECommerce.Infrastructure.Seeds
{
    public static class DataSeed
    {
        public static Role[] Roles
        {
            get
            {
                return new Role[]
                {
                    new Role { Id = new Guid("B08643FD-487F-401C-97BB-6117531ABC7A"), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = new Guid("73da2169-6fe8-4d66-897c-e2db8ed60297").ToString() }
                };
            }
        }
    }
}
