using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;


namespace Publix.Risk.IncidentIntake.Domain
{
    public class PersonInvolved
    {
        public PersonInvolved()
        { }

        public int PI_Id { get; set; }
        public EntityEntity Entity { get; set; }
        public InvolvementType Involvement { get; set; }
        public bool IsPrimaryClaimant { get; set; }
        public string? PERNR { get; set; }
    }
}
