using FluentValidation;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class FleetIncident : AutoSafetyIncident
    {
        public bool? ThirdPartyPD { get; set; }
    }

    public class FleetSafetyValidator : AbstractValidator<FleetIncident>
    {
        public FleetSafetyValidator()
        {
            RuleFor(p => p.Vehicles)
                .NotNull()
                .NotEmpty();
        }
    }
}
