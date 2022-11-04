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
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("0AC9C4CD-003D-4BCE-B5BC-732F025A57DF"),
                        Quantity=25,
                        ProductId=Guid.Parse("17A7DFF9-34FD-44E6-98C2-AA9DD60392EF"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("E2390A67-27F8-439F-9C62-3ECB09DCA511"),
                        Quantity=25,
                        ProductId=Guid.Parse("0C7DBEBF-C240-405B-9883-1606EC29DA00"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("3CA1F739-7559-4A50-B4E3-8E8D8C86D482"),
                        Quantity=25,
                        ProductId=Guid.Parse("7F6A2181-C381-4E6F-9C14-D9FC2C85B4F2"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("76E3DAC5-FACF-471D-AF6C-BA5EB733F0D8"),
                        Quantity=25,
                        ProductId=Guid.Parse("C8FE1651-FD04-4C52-A3C1-634AD6D0E413"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("B5EDE1AA-D435-4817-B11D-55A518AD338F"),
                        Quantity=25,
                        ProductId=Guid.Parse("C272683A-C8D9-4E9D-B876-16F1E6F0D557"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("1FA9D85A-1F28-4A16-A6AB-83CD29082A9D"),
                        Quantity=25,
                        ProductId=Guid.Parse("3384CC0B-0030-4972-9454-159D47149677"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("BEB721E0-0880-47B0-8A4E-298214B89134"),
                        Quantity=25,
                        ProductId=Guid.Parse("9D9791CD-737C-4DE8-BDFD-ACF51A1DBB83"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Inventory
                    {
                        Id = Guid.Parse("9249ED3F-50D1-4F62-8D2F-9E047770EA6C"),
                        Quantity=25,
                        ProductId=Guid.Parse("DA35A95D-6862-45E1-8F10-6C0A5E1200D0"),
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    }
                };
            }
        }
    }
}
