using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Entities.Membership
{
    public class Role : IdentityRole<Guid>, IAuditable
    {
        public Role()
            : base()
        {
        }

        public Role(string roleName)
            : base(roleName)
        {
        }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
