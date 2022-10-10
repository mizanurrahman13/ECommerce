using DevSkill.Data;

namespace ECommerce.Infrastructure.Entities
{
    public class ReviewImage : IAuditable, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? ImageUrl { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public Guid ReviewId { get; set; }
        public Review? Review { get; set; }
    }
}
