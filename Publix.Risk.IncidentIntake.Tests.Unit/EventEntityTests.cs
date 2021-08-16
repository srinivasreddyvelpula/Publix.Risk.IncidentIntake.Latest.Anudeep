using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.Domain;

namespace Publix.Risk.IncidentIntake.Tests.Unit
{
    [TestClass]
    public class EventEntityTests
    {
        [TestMethod]
        public void EnsurePDFPathIsOK()
        {
            EventEntity evt = new EventEntity();
            evt.EventNumber = "EV12345678MEC";

            string expectedPdfPath = "EV12345678MEC_Intake.pdf";

            Assert.AreEqual(expectedPdfPath, evt.DeterminePathForIntakePDFAttachment());
        }
    }
}
