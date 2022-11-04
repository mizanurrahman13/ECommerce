using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.DTOs;
using ECommerce.Web.Areas.Admin.Models;
using ECommerce.Web.Models;

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
