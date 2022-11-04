using DevSkill.Core.Utilities;

namespace ECommerce.Infrastructure.BusinessObjects
{
    public class Category
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

        public Category()
        {
            Id = (Id == Guid.Empty) ? IdentityGenerator.NewSequentialGuid() : Id;
        }
    }
}
