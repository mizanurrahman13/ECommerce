using AutoMapper;
using ECommerce.Membership.BusinessObjects;
using ECommerce.Membership.Services;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class DashboardModel : AdminLayoutModel
    {
        public DashboardModel()
        {

        }

        public DashboardModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
            : base(userManagerAdapter, httpContextAccessor, mapper)
        {

        }
    }
}
