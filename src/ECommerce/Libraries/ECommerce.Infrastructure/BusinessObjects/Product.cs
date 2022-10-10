using DevSkill.Core.Utilities;
using ECommerce.Infrastructure.Entities;

namespace ECommerce.Infrastructure.BusinessObjects
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool ActiveStatus { get; set; }
        public bool Featured { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public bool DeleteQueue { get; set; }//triggering delete queue

        public IList<Review>? Reviews { get; set; }
        public IList<ProductImage>? ProductImages { get; set; }
        public IList<ProductCategory>? ProductCategories { get; set; }
        public Inventory? ProductInventory { get; set; }

        public Product()
        {
            Id = (Id == Guid.Empty) ? IdentityGenerator.NewSequentialGuid() : Id;
        }
    }
}
