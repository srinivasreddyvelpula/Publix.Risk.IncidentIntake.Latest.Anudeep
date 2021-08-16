using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class QREIncident
    {
        public bool? ContainerReturned { get; set; }
        public bool? ContentsReturned { get; set; }
        public bool? DrugDispNDC { get; set; }
        public bool? DrugPresNDCNumber { get; set; }
        public bool? MedicationTaken { get; set; }
        public bool? OtherPatients { get; set; }
        public bool? OtherPatsPHIDisclosed { get; set; }
        public bool? OtherPatsWrongMed { get; set; }
        public bool? PatClaimInjury { get; set; }
        public bool? PatientContacted { get; set; }
        public bool? PatRecRxAtRptLoc { get; set; }
        public bool? QREOccuredAtRptCC { get; set; }
        public bool? SuperContacted { get; set; }
        public bool? VialWrapReturned { get; set; }
        public bool? WasDrNotified { get; set; }
        public int? CloseMethodId { get; set; }
        public int? ErrDiscoveryMethodId { get; set; }
        public int? IncidentCategoryId { get; set; }
        public int? OrigTransmitMethodId { get; set; }
        public EntityEntity[]? OtherPatientsInvolved { get; set; }
        public int? QRETypeId { get; set; }
        public int? ReportingCostCenterId { get; set; }
        public int? RxCostCenterId { get; set; }
        public int? RxTransmitMethodId { get; set; }
        public int RxTypeId { get; set; }
        public string? FillDate { get; set; }
        public string? FollowUpDate { get; set; }
        public string? LocationContactDate { get; set; }
        public string? PatientContactedDate { get; set; }
        public int? ActionId { get; set; }  // From QRE Matrix form and posted to main QRE form
        public int? CauseId { get; set; }
        public int? ReasonId { get; set; }
        public string? ReasonOther { get; set; }
        public int? VerificationStepId { get; set; }
        public string? CallComments { get; set; }
        public string? DispensedNDC { get; set; }
        public string? DoctorDirections { get; set; }
        public string? DrugDispensedNameDesc { get; set; }
        public string? DrugPresNameDesc { get; set; }
        public string? ErrorDescription { get; set; }
        public string? ErrorResolution { get; set; }
        public int? FilingPhramacistEId { get; set; }
        public string? InjuryDesc { get; set; }
        public string? LabelDirections { get; set; }
        public int? NumberOfDosesTaken { get; set; }
        public string? OriginOtherTransmit { get; set; }
        public string? OtherErrDiscMethod { get; set; }
        public string? OtherRxTransmit { get; set; }
        public string? PatientAttitude { get; set; }
        public string? PatientName { get; set; }
        public int? PharmacistContactByRiskEId { get; set; }
        public int? PharmacySupervisorEId { get; set; }
        public string? PrescribedNDC { get; set; }
        public string? ReasonDrNotCalled { get; set; }
        public string? ReasonNotContacted { get; set; }
        public string? RefilNumber { get; set; }
        public string? RxNumber { get; set; }
    }

    public class QREValidator : AbstractValidator<QREIncident>
    {
        public QREValidator()
        {
            RuleFor(p => p.ReportingCostCenterId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.RxCostCenterId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.VerificationStepId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.ReasonId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.ActionId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(p => p.QRETypeId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
