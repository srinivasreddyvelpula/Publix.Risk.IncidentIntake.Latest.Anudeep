using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class AutoSafetyIncident
    {
        public bool? FireExplosion { get; set; }
        public bool? NonVehiclePropertyDamage { get; set; }
        public int? AccidentTypeId { get; set; }
        public int? LocationTypeId { get; set; }
        public int? LocationCodeId { get; set; }
        public int? LossCategoryId { get; set; }
        public int? TimeOfDayId { get; set; }
        public EntityEntity? Vendor { get; set; }
        public int? WeatherId { get; set; }
        public InvolvedAssociate[]? EmployeeOccupants { get; set; }
        public InvolvedAssociate[]? EmployeeWitnesses { get; set; }
        public EntityEntity[]? NonEmpOccupants { get; set; }
        public EntityEntity[]? NonEmpPedestrians { get; set; }
        public EntityEntity[]? NonEmpWitnesses { get; set; }
        public Vehicle[]? Vehicles { get; set; }
        public string? AccidentDescription { get; set; }
        public string? AccidentOther { get; set; }
        public string? LocationDescription { get; set; }
        public string? MiscDescription { get; set; }

    }

    public class AutoSafetyValidator : AbstractValidator<AutoSafetyIncident>
    {
        public AutoSafetyValidator()
        {
            RuleFor(p => p.Vehicles)
                .NotNull()
                .NotEmpty();
        }
    }
}
