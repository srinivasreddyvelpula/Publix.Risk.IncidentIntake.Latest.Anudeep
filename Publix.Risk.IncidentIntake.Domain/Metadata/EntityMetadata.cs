using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.Interfaces;

namespace Publix.Risk.IncidentIntake.Domain.Metadata
{
    public class EntityMetadata : IMetadata
    {
        public string? DisplayName { get; }
        public string? Abbreviation { get; }
        public int EntityId { get; }

        public EntityMetadata(int entityId, string? displayName, string? abbreviation)
        {
            DisplayName = displayName;
            Abbreviation = abbreviation;
            EntityId = entityId;
        }

        public EntityMetadata(EntityEntity entity)
        {
            DisplayName = $"{entity.Title} {entity.FirstName} {entity.MiddleName} {entity.LastName}".Trim();
            Abbreviation = entity.Abbreviation;
            EntityId = entity.EntityId;
        }
    }
}
