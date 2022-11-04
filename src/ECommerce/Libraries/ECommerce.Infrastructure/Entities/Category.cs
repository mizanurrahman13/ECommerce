using DevSkill.Data;

namespace ECommerce.Infrastructure.Entities
{
    public class Category : IAuditable, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public IList<ProductCategory>? ProductCategories { get; set; }
    }
}
