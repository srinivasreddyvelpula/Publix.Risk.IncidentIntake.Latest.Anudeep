namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class InjuredAssociate
    {
        public int? AssociateEId { get; set; }
        public bool? Fatality { get; set; }
        public bool? PaidForDateOfInjury { get; set; }
        public int[]? BodyPartIds { get; set; }
        public int[]? InjuryIds { get; set; }
        public int? PrimaryLanguageId { get; set; }
        public int? WorkDays { get; set; }
        public string? DateLastWorked { get; set; }
        public string? PaidThroughDate { get; set; }
        public string? DateReturnedToWork { get; set; }
        public double? AvgWeeklyHours { get; set; }
        public int? CauseOfInjuryId { get; set; }
        public string? OtherCauseOfInjuries { get; set; }
        public string? InjuryDescription { get; set; }
        public string? ShiftStartTime { get; set; }
        public int? SourceOfInjuryId { get; set; }
        public double? HourlyRate { get; set; }
        public string? DateOfDeath { get; set; }
        public int? DisabilityTypeId { get; set; }

    }
}
