using AutoMapper;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Models
{
    public class PublicLayoutModel : BaseModel
    {
        public PublicLayoutModel()
        {

        }

        public PublicLayoutModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter, 
            IHttpContextAccessor httpContextAccessor, 
            IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {

        }
    }
}
