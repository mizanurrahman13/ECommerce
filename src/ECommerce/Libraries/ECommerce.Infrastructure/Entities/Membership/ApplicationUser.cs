using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure.Entities.Membership
{
    public class ApplicationUser : IdentityUser<Guid>, IAuditable
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
