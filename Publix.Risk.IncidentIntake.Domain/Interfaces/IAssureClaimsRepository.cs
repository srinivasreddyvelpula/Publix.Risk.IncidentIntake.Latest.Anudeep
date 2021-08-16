using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IAssureClaimsRepository
    {
        Task<CreateIncidentResult?> CreateEvent(CreateIncidentCommand request);

        Task<bool> UpdateClaim(ClaimEntity updatedClaim);

        Task<CreateEntityResult> CreateEntity(CreateEntityCommand newEntity);

        Task<ClaimEntity?> GetClaim(int eventId, int claimID);

        Task AttachDocumentToEvent(EventEntity @event, string serverFilename);

        Task<int> AddNewClaim(EventEntity @event, CreateIncidentCommand newClaim, int initialClaimStatusId);

        Task<EventEntity> GetEvent(int? eventId);
    }
}
