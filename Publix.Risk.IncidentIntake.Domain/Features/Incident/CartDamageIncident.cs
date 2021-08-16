using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class CartDamageIncident
    {
        public bool? CustomerIsOwner { get; set; }
        public bool? DamageMatchesCart { get; set; }
        public bool? EmpAdmitsFault { get; set; }
        public bool? ReasonNotToPay { get; set; }
        public string? ReasonExplanation { get; set; }
        public int? AllegedCauseId { get; set; }
        public int? WeatherId { get; set; }
        public EntityEntity? CustomerInvolved { get; set; }
        public InvolvedAssociate[]? EmpWitnesses { get; set; }
        public EntityEntity[]? NonEmoWitnesses { get; set; }
        public int? CartsInLot { get; set; }
        public string? CauseOther { get; set; }
        public string? CustomerDesc { get; set; }
        public string? DamageMatchExplanation { get; set; }
        public int? EmpCausedEId { get; set; }
        public string? ExtentOfDamage { get; set; }
        public Vehicle? VehicleInvolved { get; set; }
        public string? ManagerDesc { get; set; }
        public EntityEntity? OtherCustomer { get; set; }

    }

    public class CartDamageValidator : AbstractValidator<CartDamageIncident>
    {
        public CartDamageValidator()
        {
            RuleFor(p => p.VehicleInvolved)
                .NotNull();
        }
    }
}
