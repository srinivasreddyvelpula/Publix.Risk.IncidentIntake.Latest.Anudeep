namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class Vehicle
    {
        public bool? Damaged { get; set; }
        public bool? Driveable { get; set; }
        public int? VehicleTypeId { get; set; }
        public string? LicensePlate { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? VIN { get; set; }
        public int? Year { get; set; }
        public string? OwnerFirst { get; set; }
        public string? OwnerLast { get; set; }
    }
}
