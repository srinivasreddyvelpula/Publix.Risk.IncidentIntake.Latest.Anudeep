using FluentValidation;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class CQAIncident
    {
        public bool? AllegedIllness { get; set; }
        public bool? AllegedInjury { get; set; }
        public bool? AllegedForeignMaterial { get; set; }
        public bool? AssociateInvolved { get; set; }
        public bool? ProductRecall { get; set; }
        public bool? PropertyDamage { get; set; }
        public bool? RefundAccepted { get; set; }
        public bool? RefundOffered { get; set; }
        public int? NotificationMethodId { get; set; }
        public InvolvedAssociate? CQARep { get; set; }
        public Product[]? Products { get; set; }
        public double? ApproxValue { get; set; }
        public string? AllegedCause { get; set; }
        public string? AllegedIllnessDesc { get; set; }
        public int? InvolvedEmpEId { get; set; }
        public EntityEntity? Customer { get; set; }
        public string? DescribeMaterial { get; set; }
        public string? DescribeOutcome { get; set; }
        public int AssocInvolvedEId { get; set; }
        public string? IllnessOnsetTime { get; set; }
        public string? IncidentDesc { get; set; }
        public string? InjuryDesc { get; set; }
        public int? NumberInvolved { get; set; }
        public string? PropertyDamageDesc { get; set; }
        public string? SymptomLastTime { get; set; }
    }

    public class CQAValidator : AbstractValidator<CQAIncident>
    {
        public CQAValidator()
        {
            RuleFor(p => p.Products)
                .NotNull()
                .NotEmpty();
        }
    }
}
