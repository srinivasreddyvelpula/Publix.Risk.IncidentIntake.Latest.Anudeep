using Publix.Risk.IncidentIntake.Domain.Interfaces;

namespace Publix.Risk.IncidentIntake.Domain.Metadata
{
    public class EventMetadata : IMetadata
    {
        public EventMetadata(EventEntity evt)
        {
            EventNumber = evt.EventNumber;
            EventId = evt.EventId;
            Description = evt.Description;
            CreatedAt = evt.EventDate.ToString("yyyyDDmmhhMMss");
            CreatedBy = $"{evt.ReportedBy.FirstName} {evt.ReportedBy.LastName}";
        }

        public EventMetadata(string? eventNumber, int eventId, string? description, string? dateOfEvent, string? createdBy)
        {
            EventNumber = eventNumber;
            EventId = eventId;
            Description = description;
            CreatedAt = dateOfEvent;
            CreatedBy = createdBy;
        }


        public string? EventNumber { get; set; }
        public int EventId { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedAt { get; set; }
    }
}
