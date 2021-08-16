namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class Product
    {
        public bool? RetainedAsEvidence { get; set; }
        public string? CodeDate { get; set; }
        public string? ConditionReturned { get; set; }
        public string? ContainerSize { get; set; }
        public string? DateType { get; set; }
        public string? GTIN_PLU { get; set; }
        public string? Lot { get; set; }
        public string? ProductName { get; set; }
        public string? SupplierName { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
