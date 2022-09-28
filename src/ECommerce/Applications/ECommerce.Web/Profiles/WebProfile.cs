using AutoMapper;
using ECommerce.Web.Models;
using ECommerce.Membership.BusinessObjects;

namespace ECommerce.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<RegisterModel, ApplicationUser>().ReverseMap();
        }
    }
}
