using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using Publix.Risk.IncidentIntake.UI.Controllers;
using System.Linq;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    [TestClass]
    public class CodeTests : BaseTest
    {
        private CodesController controller { get; set; }

        [TestInitialize]
        public void SetupCodeTests()
        {
            base.SetupTest();
            if (provider != null)
            {
                controller = new CodesController((ILogger)provider.GetService(typeof(ILogger)), (IAssureClaimsRepository)provider.GetService(typeof(IAssureClaimsRepository)), (IConfiguration)provider.GetService(typeof(IConfiguration)), (MediatR.IMediator)provider.GetService(typeof(MediatR.IMediator)));
            }
            else
            {
                Assert.Fail("Service Provider is Null!");
            }
        }

        [TestMethod]
        public void GetCodeList_OK()
        {
            if (controller != null)
            {
                var results = controller.GetCodeTypeList().Result;

                Assert.IsNotNull(results);
                Assert.AreEqual(CodeType.GetAll().Count(), results.Count());
            }
            else
            {
                Assert.Fail("Controller is Null!");
            }
        }


        [TestMethod]
        public void AllSimpleCodesReturnValues_OK()
        {
            if (controller != null)
            {
                var results = controller.GetCodeTypeList().Result;

                foreach (var codeType in results.Where(t => t.ListType == "Simple"))
                {
                    var list = controller.GetCodesByTypeId(codeType.CodeTypeId).Result;

                    Assert.IsNotNull(list);
                    Assert.IsNotNull(list.Codes);
                    Assert.IsTrue(list.Codes.Count() > 0);
                }
            }
            else
            {
                Assert.Fail("Controller is Null!");
            }
        }


        [TestMethod]
        public void AllHierarchicalCodesReturnValues_OK()
        {
            if (controller != null)
            {
                var results = controller.GetCodeTypeList().Result;

                foreach (var codeType in results.Where(t => t.ListType == "Hierarchical"))
                {
                    var list = controller.GetCodesByTypeId(codeType.CodeTypeId).Result;

                    Assert.IsNotNull(list);
                    Assert.IsNotNull(list.Codes);
                    Assert.IsTrue(list.Codes.Count() > 0);
                }
            }
            else
            {
                Assert.Fail("Controller is Null!");
            }
        }
    }
}
