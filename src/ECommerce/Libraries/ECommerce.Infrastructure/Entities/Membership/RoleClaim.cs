using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Entities.Membership
{
    public class RoleClaim
        : IdentityRoleClaim<Guid>, IAuditable
    {
        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }

}
