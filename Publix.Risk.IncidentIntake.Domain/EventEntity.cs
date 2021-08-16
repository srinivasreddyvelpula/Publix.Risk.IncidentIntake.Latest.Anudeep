using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Publix.Risk.IncidentIntake.Domain
{
    public class EventEntity : Address
    {
        public EventEntity()
        {
            EventType = EventType.WorkersCompensation;
            StatusCode = StatusType.None;
            Department = new EntityEntity();
            EventNumber = "EV" + new Random(7).Next(60000, 99999).ToString();
        }

        public int EventId { get; set; }
        public string EventNumber { get; set; }
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? ReportedAt { get; set; }
        public IEnumerable<ClaimEntity>? Claims { get; set; }
        public int? ReportedById { get; set; }
        public virtual EntityEntity ReportedBy { get; set; }
        public int? EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }
        public IEnumerable<PersonInvolved>? Persons { get; set; }
        public int? StatusCodeId { get; set; }
        public virtual StatusType StatusCode { get; set; }
        public int? DepartmentId { get; set; }
        public virtual EntityEntity? Department { get; set; }

        public string DeterminePathForIntakePDFAttachment()
        {
            string path = $"{EventNumber}_Intake.pdf";

            return path;
        }
    }

}
