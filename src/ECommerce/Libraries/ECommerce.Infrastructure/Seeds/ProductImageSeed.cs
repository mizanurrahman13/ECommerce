using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Seeds
{
    public static class ProductImageSeed
    {
        public static ProductImage[] ProductImages
        {
            get
            {
                return new ProductImage[]
                {
                    new ProductImage
                    {
                        Id = Guid.Parse("168528CC-7BA4-452D-B4BF-D8032B3C2EF7"),
                        Url="Files\\NoImageFound.png",
                        ProductId = Guid.Parse("7410BDFD-C2F1-4F29-B8B1-1321810CC9A9"),
                        CreatedDate=DateTime.Now,
                        UpdatedDate=DateTime.Now,
                        CreatedBy="admin@gmail.com",
                        UpdatedBy="admin@gmail.com"                        
                    },
                    new ProductImage
                    {
                        Id = Guid.Parse("9B545B2C-7E36-41AC-B39A-052CD61C8D4C"),
                        Url="Files\\NoImageFound.png",
                        ProductId = Guid.Parse("72A73A5F-1930-49E3-B924-D72B59C050A2"),
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
