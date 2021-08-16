using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class CustomerInjuryIncident
    {
        public bool? CautionPresent { get; set; }
        public bool? EMSCalled { get; set; }
        public bool? EquipmentInvolved { get; set; }
        public bool? MoverInvolved { get; set; }
        public bool? ReasonNotToPay { get; set; }
        public bool? SkidMarks { get; set; }
        public bool? StockedPlanogram { get; set; }
        public bool? SubstanceOnFloor { get; set; }
        public bool? VendorInvolved { get; set; }
        public int? DetailedLocationId { get; set; }
        public int? FloorColorId { get; set; }
        public int? FloorTypeId { get; set; }
        public int? IncidentTypeId { get; set; }
        public int? InOutId { get; set; }
        public int? LastStockedByEId { get; set; }
        public int? ObjectTypeId { get; set; }
        public int? TrippedOverId { get; set; }
        public int? WeatherId { get; set; }
        public InvolvedAssociate[]? EmpWitnesses { get; set; }
        public int[]? EquipmentIds { get; set; }
        public EntityEntity[]? NonEmpWitnesses { get; set; }
        public string? CustomerClothing { get; set; }
        public string? CustomerDesc { get; set; }
        public string? EstTimeSinceInspection { get; set; }
        public string? FloorOther { get; set; }
        public string? IncidentOther { get; set; }
        public EntityEntity? InjuredPerson { get; set; }
        public int? LastInspectedEId { get; set; }
        public string? LocationOther { get; set; }
        public string? MgrDesc { get; set; }
        public string? ObjectDesc { get; set; }
        public string? ObjectOrigin { get; set; }
        public string? ObjectOtherDesc { get; set; }
        public int? StockedByEId { get; set; }
        public string? ReasonExplanation { get; set; }
        public string? ShoeColor { get; set; }
        public string? SubstanceDetail { get; set; }
        public string? SubstanceOther { get; set; }
        public string? SubstanceSource { get; set; }
        public string? TrippedOther { get; set; }
    }

    public class CustInjuryValidator : AbstractValidator<CustomerInjuryIncident>
    {
        public CustInjuryValidator()
        {
            RuleFor(p => p.InjuredPerson)
                .NotNull();
        }
    }
}
