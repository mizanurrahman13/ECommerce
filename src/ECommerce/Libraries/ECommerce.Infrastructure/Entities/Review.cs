using DevSkill.Data;

namespace ECommerce.Infrastructure.Entities
{
    public class Review : IAuditable, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int Stars { get; set; }
        public string? ReviewMessage { get; set; }
        public Guid UserId { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public IList<ReviewImage>? ReviewImages { get; set; }
    }
}
