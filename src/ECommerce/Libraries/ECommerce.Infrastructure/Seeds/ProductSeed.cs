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
                        Id = Guid.Parse("17A7DFF9-34FD-44E6-98C2-AA9DD60392EF"),
                        Name = "Mango",
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
                        Id = Guid.Parse("0564DC12-CA23-4508-8F53-8A4C5AEFE1A9"),
                        Name = "JackFruit",
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
                        Id = Guid.Parse("0C7DBEBF-C240-405B-9883-1606EC29DA00"),
                        Name = "Apple",
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
                        Id = Guid.Parse("7F6A2181-C381-4E6F-9C14-D9FC2C85B4F2"),
                        Name = "Banana",
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
                        Id = Guid.Parse("C8FE1651-FD04-4C52-A3C1-634AD6D0E413"),
                        Name = "Black Berry",
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
                        Id = Guid.Parse("3384CC0B-0030-4972-9454-159D47149677"),
                        Name = "Blue Berry",
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
                        Id = Guid.Parse("C272683A-C8D9-4E9D-B876-16F1E6F0D557"),
                        Name = "Green Berry",
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
                        Id = Guid.Parse("9D9791CD-737C-4DE8-BDFD-ACF51A1DBB83"),
                        Name = "Green Apple",
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
                        Id = Guid.Parse("DA35A95D-6862-45E1-8F10-6C0A5E1200D0"),
                        Name = "Date",
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
