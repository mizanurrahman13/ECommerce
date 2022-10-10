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
                        Id = Guid.Parse("F23B443B-2185-4DD7-9952-8A91185E5244"),
                        Name = "Default",
                        Description = "Category Example....",
                        ImageUrl = "Files/NoImageFoung.png",
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "Admin@gmail.com"
                    }
                };
            }
        }
    }
}
