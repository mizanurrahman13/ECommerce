namespace ECommerce.Infrastructure.BusinessObjects
{
    public class ProductDelete
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime TriggeredOn { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
