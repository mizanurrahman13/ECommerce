using AutoMapper;
using ECommerce.Membership.BusinessObjects;
using EntityEO = ECommerce.Infrastructure.Entities.Membership.ApplicationUser;

namespace ECommerce.Membership.Profiles
{
    public class MembershipProfile : Profile
    {
        public MembershipProfile()
        {
            CreateMap<ApplicationUser, EntityEO>().ReverseMap();
        }
    }
}
