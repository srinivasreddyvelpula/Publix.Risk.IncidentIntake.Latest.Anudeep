using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Persistence
{
    public class PDFService : IPDFService
    {
        private string SendEmailFrom { get; }
        private ILogger _logger { get; }
        private IRMXContext _dbContext { get; }
        private IAssureClaimsRepository _repo { get; }
        private IPublixSendMailService _mailService { get; }
        private IPDF_IO _io { get; }

        private PdfFont baseFont;
        private PdfFont titleFont;
        private PdfFont subTitleFont;


        public PDFService(ILogger logger, IConfiguration config, IRMXContext context, IAssureClaimsRepository repo, IPublixSendMailService service, IPDF_IO io)
        {
            SendEmailFrom = config["SendMail_From"];
            _io = io;
            _logger = logger;
            _dbContext = context;
            _repo = repo;
            _mailService = service;

            //embed fonts and setup font objects
            baseFont = PdfFontFactory.CreateFont(Resource1.Lato_Regular, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            titleFont = PdfFontFactory.CreateFont(Resource1.Lato_Bold, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
            subTitleFont = PdfFontFactory.CreateFont(Resource1.Lato_Black, PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED);
        }


        public async Task<PdfDocument> GenerateAndAttachPDF(EventEntity @event, CreateIncidentCommand incident)
        {
            if (string.IsNullOrEmpty(@event.EventNumber))
            {
                throw new InvalidOperationException("Event has no EventNumber");
            }

            string localFilename = _io.GetTempPDFFilename(@event);
            FileStream fs = System.IO.File.Open(localFilename, FileMode.CreateNew);
            WriterProperties writerProps = new WriterProperties();
            writerProps.UseSmartMode();

            var writer = new PdfWriter(fs, writerProps);

            // Generate PDF
            PdfDocument pdf = GeneratePdfDocument(writer, @event.EventNumber, incident, out string title);
            pdf.GetWriter().Flush();
            pdf.Close();

            try
            {
                // Attach to Event
                await AttachPDFToEvent(@event, localFilename);

                // Email PDF
                var sendee = _dbContext.Associates.Where(a => a.EntityId == @event.ReportedById).First();
                string? sendTo = sendee.PERNR + "@publix.com";

                await SendPDFInEmail(title, localFilename, sendTo);

                System.IO.File.Delete(localFilename);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, null);
            }

            return pdf;
        }


        private PdfDocument GeneratePdfDocument(PdfWriter writer, string eventNumber, CreateIncidentCommand incident, out string title)
        {
            PdfDocument pdf = new PdfDocument(writer);
            Document doc = new Document(pdf);

            AddHeaderToFirstPage(doc, eventNumber, incident.EventTypeId, out title);

            AddRemainingItems(doc, incident);

            return pdf;
        }


        private void AddHeaderToFirstPage(Document doc, string eventNumber, int incidentTypeId, out string title)
        {
            string subtitle = eventNumber;

            switch (incidentTypeId)
            {
                case 2315:  //auto safety
                    title = $"Auto Safety Incident Report";
                    break;

                case 2317:  //Customer Incident
                    title = "Customer Incident Report";
                    break;

                case 505:  //Pharmacy QRE
                    title = "Pharmacy Quality Releated Event Report";
                    break;

                case 460250:  //Fleet Safety
                    title = "Fleet Safety Incident Report";
                    break;

                case 2320:  //Property Damage
                    title = "Property Damage Incident Report";
                    break;

                case 2521:  //CQA
                    title = "Customer QA Incident Report";
                    break;

                case 2321:  //Cart Damage
                    title = "Cart Damage Incident Report";
                    break;

                default:    //Worker's Comp:  2316
                    title = "Associate Injury Incident Report";
                    break;
            }

            Text pdfTitle = new Text(title).SetFont(titleFont).SetFontSize(16).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            Text pdfSubTitle = new Text(subtitle).SetFont(subTitleFont).SetFontSize(14).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            Text warning = new Text("This report is prepared in anticipation of litigation and is privileged and confidential information. Do not share with the customer or anyone outside of Publix without authorization from Risk Management.").SetFont(baseFont).SetFontSize(12).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            doc.Add(new Paragraph(pdfTitle));
            doc.Add(new Paragraph(pdfSubTitle));
            doc.Add(new Paragraph(warning).SetMarginTop(12).SetMarginBottom(12));

        }


        private void AddRemainingItems(Document doc, CreateIncidentCommand data, object subData = null)
        {
            Table table = new Table(2).SetAutoLayout();
            Border border = new SolidBorder(iText.Kernel.Colors.ColorConstants.BLACK, 1);
            Style solidBorder = new Style().SetBorder(border);

            if (subData == null)
            {
                //loop through items in data list into two column table with name in first column and value in second column
                table.AddStyle(solidBorder);

                //setup table header row
                Paragraph p1 = new Paragraph().Add(new Text("Name").SetFont(baseFont).SetBold());
                Paragraph p2 = new Paragraph().Add(new Text("Value").SetFont(baseFont).SetBold());
                Cell nameCell = new Cell(1, 1).Add(p1).AddStyle(solidBorder);
                Cell valueCell = new Cell(1, 1).Add(p2).AddStyle(solidBorder);
                table.AddHeaderCell(nameCell);
                table.AddHeaderCell(valueCell);

                // fill in remaining data
                foreach (var pair in data.GetType().GetProperties())
                {
                    if (pair.PropertyType.IsClass && pair.GetValue(data) != null)
                    {
                        AddRemainingItems(doc, data, pair.GetValue(data));
                    }
                    else
                    {
                        Paragraph name = new Paragraph().Add(new Text(pair.Name).SetFont(baseFont));
                        Paragraph value = new Paragraph().Add(new Text(pair.GetValue(data)?.ToString()).SetFont(baseFont));
                        Cell cell1 = new Cell(1, 1).Add(name).AddStyle(solidBorder);
                        Cell cell2 = new Cell(1, 1).Add(value).AddStyle(solidBorder);
                        table.AddCell(cell1);
                        table.AddCell(cell2);
                    }
                }
            }
            else
            {
                // fill in remaining data
                foreach (var pair in subData.GetType().GetProperties())
                {
                    if (pair.PropertyType.IsClass && pair.GetValue(subData) != null)
                    {
                        AddRemainingItems(doc, data, pair.GetValue(subData));
                    }
                    else
                    {
                        Paragraph name = new Paragraph().Add(new Text("\t" + pair.Name).SetFont(baseFont));
                        Paragraph value = new Paragraph().Add(new Text("\t" + pair.GetValue(subData)?.ToString()).SetFont(baseFont));
                        Cell cell1 = new Cell(1, 1).Add(name).AddStyle(solidBorder);
                        Cell cell2 = new Cell(1, 1).Add(value).AddStyle(solidBorder);
                        table.AddCell(cell1);
                        table.AddCell(cell2);
                    }
                }
            }
            doc.Add(table);
        }


        private async Task AttachPDFToEvent(EventEntity @event, string localFilename)
        {
            // copy to server
            string attachmentFilename = _io.MovePDFToFileServer(@event, localFilename);

            // create attachment record in DB
            await _repo.AttachDocumentToEvent(@event, attachmentFilename);
        }


        private async Task SendPDFInEmail(string subject, string localFilename, string sendToEmail)
        {
            long length = new FileInfo(localFilename).Length;
            byte[] buffer = new byte[length];
            System.IO.File.Open(localFilename, FileMode.Open).Read(buffer, 0, (int)length);

            string body = "Attached is your copy of your submitted incident.  Please keep for your records.";

            List<Message> emails = new List<Message>();
            Message email = new Message()
            {
                From = new Recipient() { EmailAddress = new EmailAddress() { Address = SendEmailFrom } },
                ToRecipients = new List<Recipient>() { new Recipient() { EmailAddress = new EmailAddress() { Address = sendToEmail } } },
                Subject = subject,
                Body = new ItemBody() { Content = body }
            };

            email.Attachments = new MessageAttachmentsCollectionPage()
            {
                new FileAttachment()
                {
                    Name = "incident_submission.pdf",
                    ContentType = "application/pdf",
                    ContentBytes = buffer
                }
            };

            emails.Add(email);

            await _mailService.SendEmail(emails);
        }
    }
}
