using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Seeds
{
    public static class ProductCategorySeed
    {
        public static ProductCategory[] ProductCategories
        {
            get
            {
                return new ProductCategory[]
                {
                    new ProductCategory
                    {
                        ProductId= Guid.Parse("7F6A2181-C381-4E6F-9C14-D9FC2C85B4F2"), 
                        CategoryId= Guid.Parse("7A61CF49-D11A-494D-95CA-C649ED215773")
                    },
                    new ProductCategory
                    {
                        ProductId= Guid.Parse("7F6A2181-C381-4E6F-9C14-D9FC2C85B4F2"), 
                        CategoryId=Guid.Parse("D6DCF59A-0CF7-4C22-AFF5-38CD0223ACA0")
                    },
                    new ProductCategory
                    {
                        ProductId= Guid.Parse("7F6A2181-C381-4E6F-9C14-D9FC2C85B4F2"),
                        CategoryId= Guid.Parse("0B42EB8C-A7FD-46AA-A88C-8D656B016115")
                    },
                    new ProductCategory
                    {
                        ProductId= Guid.Parse("17A7DFF9-34FD-44E6-98C2-AA9DD60392EF"),
                        CategoryId= Guid.Parse("7A61CF49-D11A-494D-95CA-C649ED215773")
                    },
                    new ProductCategory
                    {
                        ProductId= Guid.Parse("0564DC12-CA23-4508-8F53-8A4C5AEFE1A9"),
                        CategoryId=Guid.Parse("7A61CF49-D11A-494D-95CA-C649ED215773")
                    },
                    new ProductCategory
                    {
                        ProductId= Guid.Parse("0C7DBEBF-C240-405B-9883-1606EC29DA00"),
                        CategoryId= Guid.Parse("7A61CF49-D11A-494D-95CA-C649ED215773")
                    }
                };
            }
        }
    }
}
