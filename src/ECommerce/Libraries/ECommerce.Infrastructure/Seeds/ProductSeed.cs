using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Seeds
{
    public static class ProductSeed
    {
        public static Product[] Products
        {
            get
            {
                return new Product[]
                {
                    new Product
                    {
                        Id = Guid.Parse("7410BDFD-C2F1-4F29-B8B1-1321810CC9A9"),
                        Name = "Apex Shoes",
                        Description="This is the best product...........",
                        UnitPrice=2500,
                        DiscountedPrice=3000,
                        ActiveStatus=true,
                        Featured=false,                        
                        CreatedDate=DateTime.Now,
                        UpdatedDate=DateTime.Now,
                        CreatedBy="admin@gmail.com",
                        UpdatedBy="admin@gmail.com"
                    },
                    new Product
                    {
                        Id = Guid.Parse("72A73A5F-1930-49E3-B924-D72B59C050A2"),
                        Name = "Bata Shoes",
                        Description="This is the best product...........",
                        UnitPrice=2500,
                        DiscountedPrice=3000,
                        ActiveStatus=true,
                        Featured=false,
                        CreatedDate=DateTime.Now,
                        UpdatedDate=DateTime.Now,
                        CreatedBy="admin@gmail.com",
                        UpdatedBy="admin@gmail.com"
                    }
                };

            }
        }
    }
}
