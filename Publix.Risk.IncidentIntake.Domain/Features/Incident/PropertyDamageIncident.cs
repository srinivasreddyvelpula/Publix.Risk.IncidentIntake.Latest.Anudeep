using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class PropertyDamageIncident
    {
        public bool? AssociateInvolved { get; set; }
        public bool? ReasonNotToPay { get; set; }
        public bool? VendorInvolved { get; set; }
        public double? ApproxValue { get; set; }
        public EntityEntity? Location { get; set; }
        public InvolvedAssociate[]? EmpWitnesses { get; set; }
        public EntityEntity[]? NonEmpWitnesses { get; set; }
        public string? AllegedCause { get; set; }
        public InvolvedAssociate? InvolvedAssociate { get; set; }
        public string? CustomerDesc { get; set; }
        public EntityEntity? Customer { get; set; }
        public string? MgrDesc { get; set; }
        public string? PropertyDamaged { get; set; }
        public string? ReasonExplanation { get; set; }
    }

    public class PropDamageValidator : AbstractValidator<PropertyDamageIncident>
    {
        public PropDamageValidator()
        {
            RuleFor(p => p.Customer)
                .NotNull();

            RuleFor(p => p.PropertyDamaged)
                .NotNull()
                .NotEmpty();
        }
    }

}
