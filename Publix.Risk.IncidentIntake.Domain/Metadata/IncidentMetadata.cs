using Newtonsoft.Json;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using Publix.Risk.IncidentIntake.Domain.Interfaces;

namespace Publix.Risk.IncidentIntake.Domain.Metadata
{
    public class IncidentMetadata : IMetadata
    {
        public string JSONIncident { get; set; }

        public IncidentMetadata(CreateIncidentCommand incident)
        {
            JSONIncident = JsonConvert.SerializeObject(incident);
        }

        public IncidentMetadata(string jsonIncident)
        {
            JSONIncident = jsonIncident;
        }
    }
}
