using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.Domain.Core;
using Publix.Risk.IncidentIntake.Domain.Core.Interfaces;
using Publix.Risk.IncidentIntake.Domain.Core.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Publix.Risk.IncidentIntake.Test.Core.Integration
{
    [TestClass]
    public class PDFService_Tests : BaseIntegrationTest
    {
        [TestMethod]
        public void GeneratePDF_OK()
        {
            Event evt = new Event()
            {
                EventNumber = "EV029212343458435MC",
                EventId = 754393,
                Description = "Test PDF Generation Event"
            };

            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            for (int i = 1; i < 100; i++)
            {
                data.Add(new KeyValuePair<string, string>(i.ToString().PadLeft(5, '0'), GetRandomText(i)));
            }

            Incident incident = new Incident();
            incident.Type = ClaimType.CustomerInjury;
            incident.Data = data;

            IPDFService service = (IPDFService)Server.Services.GetService(typeof(IPDFService));

            var pdf = service.GenerateAndAttachPDF(evt, incident);

            Assert.IsNotNull(pdf);
        }
    }
}
