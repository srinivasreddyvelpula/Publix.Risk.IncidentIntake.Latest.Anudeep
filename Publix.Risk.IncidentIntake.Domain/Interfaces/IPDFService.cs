using iText.Kernel.Pdf;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IPDFService
    {
        Task<PdfDocument> GenerateAndAttachPDF(EventEntity @event, CreateIncidentCommand incident);
    }
}