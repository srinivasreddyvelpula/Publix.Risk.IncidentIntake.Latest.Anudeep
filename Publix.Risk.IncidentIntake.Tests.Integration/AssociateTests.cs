using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.UI.Controllers;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    [TestClass]
    public class AssociateTests : BaseTest
    {
        private AssociateController controller { get; set; }

        [TestInitialize]
        public void SetupCodeTests()
        {
            base.SetupTest();
            if (provider != null)
            {
                controller = new AssociateController((ILogger)provider.GetService(typeof(ILogger)), (IConfiguration)provider.GetService(typeof(IConfiguration)), (MediatR.IMediator)provider.GetService(typeof(MediatR.IMediator)));
            }
            else
            {
                Assert.Fail("Service Provider is Null!");
            }
        }

        [TestMethod]
        public void SeachAssociateTests()
        {
            string last = "Curtis";

            var results = controller.GetAssociates(null, last, null, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(ResultsPass(null, last, null, results));

            string first = "Charles";

            results = controller.GetAssociates(first, last, null, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(ResultsPass(first, last, null, results));

            string costCenter = "17733000";

            results = controller.GetAssociates(first, last, null, costCenter).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(ResultsPass(first, last, costCenter, results));
        }

        [TestMethod]
        public void GetAssociate_OK()
        {
            string pernr = "00440350";

            var emp = controller.GetAssociateByPERNR(pernr).Result;

            Assert.IsNotNull(emp);
            Assert.AreEqual(pernr, emp.Associate.PERNR);
            Assert.AreEqual("Store 1236", emp.Associate.Department.LastName);
            Assert.IsTrue(emp.Associate.Entity.FirstName.Contains("Stuart"));
            Assert.IsTrue(emp.Associate.Entity.LastName.Contains("Little"));
        }

        private bool ResultsPass(string? first, string? last, string? costCenter, Domain.Features.Associate.SearchAssociatesResult results)
        {
            foreach (var result in results.Results)
            {
                if (!string.IsNullOrEmpty(first) && !result.FirstName.Contains(first) ||
                    !string.IsNullOrEmpty(last) && !result.LastName.Contains(last) ||
                    !string.IsNullOrEmpty(costCenter) && !result.CostCenter.Contains(costCenter))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
