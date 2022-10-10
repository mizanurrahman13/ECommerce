using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using CategoryEntity = ECommerce.Infrastructure.Entities.Category;

namespace ECommerce.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<CategoryEntity, Category>().ReverseMap();
        }
    }
}
