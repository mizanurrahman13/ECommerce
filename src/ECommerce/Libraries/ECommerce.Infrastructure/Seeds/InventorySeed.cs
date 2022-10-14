using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Seeds
{
    public static class InventorySeed
    {
        public static Inventory[] Inventories
        {
            get
            {
                return new Inventory[]
                {
                    new Inventory
                    {
                        Id = Guid.Parse("F23B443B-2185-4DD7-9952-8A91185E5244"),
                        Quantity=23, 
                        ProductId=Guid.Parse("7410BDFD-C2F1-4F29-B8B1-1321810CC9A9"),                        
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("97081FB9-F963-4125-AEE3-AE7DEAECB0EC"),
                        Quantity=25,
                        ProductId=Guid.Parse("72A73A5F-1930-49E3-B924-D72B59C050A2"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    }
                };
            }
        }
    }
}
