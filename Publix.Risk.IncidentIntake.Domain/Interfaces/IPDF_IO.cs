namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IPDF_IO
    {
        string GetTempPDFFilename(EventEntity @event);

        string MovePDFToFileServer(EventEntity @event, string localFilename);
    }
}
