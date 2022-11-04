using DevSkill.Data;

namespace ECommerce.Infrastructure.Entities
{
    public class Inventory : IAuditable, IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
