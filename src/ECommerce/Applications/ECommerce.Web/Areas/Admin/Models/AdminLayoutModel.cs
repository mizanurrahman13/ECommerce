using AutoMapper;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;
using ECommerce.Web.Models;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class AdminLayoutModel : BaseModel
    {
        public AdminLayoutModel()
        {

        }

        public AdminLayoutModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter, IHttpContextAccessor httpContextAccessor, IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {

        }
    }
}
