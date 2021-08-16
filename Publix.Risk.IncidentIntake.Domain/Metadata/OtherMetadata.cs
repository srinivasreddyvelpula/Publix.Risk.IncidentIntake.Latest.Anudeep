using Publix.Risk.IncidentIntake.Domain.Interfaces;

namespace Publix.Risk.IncidentIntake.Domain.Metadata
{
    public class OtherMetadata : IMetadata
    {
        public object StateData { get; }

        public OtherMetadata(object stateData)
        {
            StateData = stateData;
        }
    }
}
