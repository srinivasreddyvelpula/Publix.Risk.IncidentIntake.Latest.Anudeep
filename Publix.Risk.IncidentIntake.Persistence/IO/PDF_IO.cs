using Microsoft.Extensions.Configuration;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System.IO;


namespace Publix.Risk.IncidentIntake.Persistence.IO
{
    public class PDF_IO : IPDF_IO
    {
        private string FileServerAttachementPath { get; }

        public PDF_IO(IConfiguration config)
        {
            FileServerAttachementPath = config["FileServerAttachementPath"];
        }


        public string GetTempPDFFilename(EventEntity @event)
        {
            return Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + $".{@event.EventId}.pdf");
        }


        public string MovePDFToFileServer(EventEntity @event, string localFilename)
        {
            // move locally created PDF file that was created using the temp file generated in method above
            // to file server in correct folder and return final file server name and full path.

            string filename = "";// @event.DeterminePathForIntakePDFAttachment();
            string finalPath = FileServerAttachementPath;

            string finalFilename = Path.Combine(finalPath, filename);

            File.Copy(localFilename, finalFilename);

            return finalFilename;
        }
    }
}
