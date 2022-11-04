using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using CategoryEntity = ECommerce.Infrastructure.Entities.Category;
using ProductCategoryEntity = ECommerce.Infrastructure.Entities.ProductCategory;
using ProductDeleteEntity = ECommerce.Infrastructure.Entities.ProductDelete;
using ProductEntity = ECommerce.Infrastructure.Entities.Product;
using ProductImageEntity = ECommerce.Infrastructure.Entities.ProductImage;

namespace ECommerce.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CategoryEntity, Category>().ReverseMap();
            CreateMap<ProductEntity, Product>().ReverseMap();
            CreateMap<ProductCategoryEntity, ProductCategory>().ReverseMap();
            CreateMap<ProductImageEntity, ProductImage>().ReverseMap();
            CreateMap<ProductDeleteEntity, ProductDelete>().ReverseMap();
        }
    }
}
