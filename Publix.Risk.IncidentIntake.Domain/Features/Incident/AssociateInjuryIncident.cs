using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class AssociateInjuryIncident
    {
        public int EmployeeEId { get; set; }
        public bool? BloodOPIM { get; set; }
        public bool? ChemicalsInvolved { get; set; }
        public bool? EmpDrugTested { get; set; }
        public bool? EmpFell { get; set; }
        public bool? EquipmentInvolved { get; set; }
        public bool? HospitalOvernight { get; set; }
        public bool? IncidentAtPublix { get; set; }
        public bool? MedicalCareSought { get; set; }
        public bool? MgrAgrees { get; set; }
        public bool? OSHARecordable { get; set; }
        public bool? PPERelated { get; set; }
        public bool? PPEWorn { get; set; }
        public bool? TransportedEMS { get; set; }
        public bool? TreatedInER { get; set; }
        public bool? VendorInvolved { get; set; }
        public int? ActivityEngagedId { get; set; }
        public int[]? Chemicals { get; set; }
        public int ClaimTypeId { get; set; }    //required
        public int? DetailedLocation { get; set; }
        public int[]? Equipment { get; set; }
        public int? FloorTypeId { get; set; }
        public int? InOutId { get; set; }
        public int? LocationEId { get; set; }
        public Location? NonPublixLocation { get; set; }
        public int? RespDeptEId { get; set; }
        public int? ShiftId { get; set; }
        public int? ClaimJuris { get; set; }
        public int? CloseReasonId { get; set; }
        public string? DateTimeClaimClosed { get; set; }
        public int? ClaimStatusId { get; set; }
        public InvolvedAssociate[]? EmpWitnesses { get; set; }
        public EntityEntity[]? NonEmpInvloved { get; set; }
        public EntityEntity[]? NonEmpWitnesses { get; set; }
        public InvolvedAssociate[]? OtherEmpInvolved { get; set; }
        public string? EmpActions { get; set; }
        public string? EmpDescription { get; set; }
        public InjuredAssociate? InjuredAssociate { get; set; }
        public string? ReporterPERNR { get; set; }
        public string? OtherExplanation { get; set; }
        public string? OtherFlooring { get; set; }
        public string? OtherIncident { get; set; }
        public string? LocationDescription { get; set; }
        public string? OtherLocation { get; set; }
        public Location? MedicalLocation { get; set; }
        public string? MedicalProfessional { get; set; }
        public EntityEntity? Vendor { get; set; }

    }

    public class AssocInjuryValidator : AbstractValidator<AssociateInjuryIncident>
    {
        public AssocInjuryValidator()
        {
            this.RuleFor(p => p.EmployeeEId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.ClaimTypeId)
                .NotNull()
                .GreaterThan(0);
        }
    }

}
