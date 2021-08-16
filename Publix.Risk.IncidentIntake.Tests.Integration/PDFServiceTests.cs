using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    [TestClass]
    public class PDFServiceTests : BaseTest
    {
        private IPDFService? service { get; set; }

        [TestInitialize]
        public void SetupCodeTests()
        {
            base.SetupTest();
            if (provider != null)
            {
                service = (IPDFService)provider.GetService(typeof(IPDFService));
            }
            else
            {
                Assert.Fail("Service Provider is Null!");
            }
        }

        [TestMethod]
        public void PDFFails_NullData()
        {
            var result = service.GenerateAndAttachPDF(null, null);
        }
    }
}
