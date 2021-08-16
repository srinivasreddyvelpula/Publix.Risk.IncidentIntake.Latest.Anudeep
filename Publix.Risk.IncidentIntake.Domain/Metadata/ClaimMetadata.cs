using Publix.Risk.IncidentIntake.Domain.Interfaces;

namespace Publix.Risk.IncidentIntake.Domain.Metadata
{
    public class ClaimMetadata : IMetadata
    {
        public int ClaimID { get; }
        public string? ClaimNumber { get; }

        public ClaimMetadata(ClaimEntity claim)
        {
            ClaimID = claim.ClaimId;
            ClaimNumber = claim.ClaimNumber;
        }

        public ClaimMetadata(int id, string number)
        {
            ClaimID = id;
            ClaimNumber = number;
        }
    }
}
