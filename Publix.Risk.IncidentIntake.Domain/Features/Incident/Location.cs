namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class Location
    {
        public string LocationName { get; set; }
        public string Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? Country { get; set; }
        public int? StateId { get; set; }
        public string? Zip { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        internal int? EntityId { get; set; } = null;
    }
}
