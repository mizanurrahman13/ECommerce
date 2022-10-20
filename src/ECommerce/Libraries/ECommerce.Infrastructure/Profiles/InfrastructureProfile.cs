using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using CategoryEntity = ECommerce.Infrastructure.Entities.Category;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;
using ProductCategoryEntity = ECommerce.Infrastructure.Entities.ProductCategory;

namespace ECommerce.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CategoryEntity, Category>().ReverseMap();
            CreateMap<ProductEntity, Product>().ReverseMap();
            CreateMap<ProductCategoryEntity, ProductCategory>().ReverseMap();
        }
    }
}
