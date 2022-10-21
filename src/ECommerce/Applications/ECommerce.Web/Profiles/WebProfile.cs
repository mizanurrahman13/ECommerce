using AutoMapper;
using ECommerce.Web.Models;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.DTOs;
using ECommerce.Web.Areas.Admin.Models;
using ECommerce.Infrastructure.BusinessObjects;

namespace ECommerce.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UserBasicInfoDto>().ReverseMap();
            CreateMap<CategoryCreateModel, Category>().ReverseMap();
            //CreateMap<ProductEditModel, Product>().ReverseMap();
        }
    }
}
