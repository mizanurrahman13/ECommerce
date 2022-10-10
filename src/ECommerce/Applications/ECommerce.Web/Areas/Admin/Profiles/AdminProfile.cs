using AutoMapper;
using ECommerce.Infrastructure.BusinessObjects;
using ECommerce.Web.Areas.Admin.Models;

namespace ECommerce.Web.Areas.Admin.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<CategoryCreateModel, Category>().ReverseMap();
        }
    }
}
