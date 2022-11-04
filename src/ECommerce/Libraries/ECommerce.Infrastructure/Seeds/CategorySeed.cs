using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.Seeds
{
    public static class CategorySeed
    {
        public static Category[] Categories
        {
            get
            {
                return new Category[]
                {
                    new Category
                    {
                        Id = Guid.Parse("C405483E-B35C-4C4E-9E7E-387B5527F0B7"),
                        Name = "Default",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Category
                    {
                        Id = Guid.Parse("7A61CF49-D11A-494D-95CA-C649ED215773"),
                        Name = "Food",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Category
                    {
                        Id = Guid.Parse("D6DCF59A-0CF7-4C22-AFF5-38CD0223ACA0"),
                        Name = "Vegetable",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Category
                    {
                        Id = Guid.Parse("0B42EB8C-A7FD-46AA-A88C-8D656B016115"),
                        Name = "Seasonal Food",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Category
                    {
                        Id = Guid.Parse("136E59E2-2046-460F-AD0E-60B75F3748C9"),
                        Name = "Phone",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Category
                    {
                        Id = Guid.Parse("7D0059E3-816C-44E1-8E36-ADB7C74E1C7C"),
                        Name = "Cloths",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    },
                    new Category
                    {
                        Id = Guid.Parse("7E2C655F-5E84-48C7-BDA1-AD178A7BE899"),
                        Name = "Gadgets",
                        Description = "Category Description Example....",
                        ImageUrl = "Files\\NoImageFound.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    }
                };
            }
        }
    }
}
