using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.UI.Controllers;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    [TestClass]
    public class EntityTests : BaseTest
    {
        private EntityController controller { get; set; }

        [TestInitialize]
        public void SetupCodeTests()
        {
            base.SetupTest();
            if (provider != null)
            {
                controller = new EntityController((ILogger)provider.GetService(typeof(ILogger)), (IConfiguration)provider.GetService(typeof(IConfiguration)), (MediatR.IMediator)provider.GetService(typeof(MediatR.IMediator)));
            }
            else
            {
                Assert.Fail("Service Provider is Null!");
            }
        }

        [TestMethod]
        public void SeachEntitiesTests()
        {
            string last = "Deli";

            var results = controller.SearchEntities(null, last, null, null, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(ResultsPass(null, last, null, null, results));

            string city = "Lakeland";

            results = controller.SearchEntities(null, last, null, city, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(ResultsPass(null, last, null, city, results));

            string abbrev = "17631600";

            results = controller.SearchEntities(null, last, abbrev, null, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(ResultsPass(null, last, abbrev, null, results));
        }

        [TestMethod]
        public void GetEntity_OK()
        {
            int id = 89699;

            var entity = controller.GetEntityById(id).Result;

            Assert.IsNotNull(entity);
            Assert.AreEqual("USA", entity.Entity.Country.ShortCode);
            Assert.AreEqual(id, entity.Entity.EntityId);
            Assert.AreEqual("M", entity.Entity.Sex.ShortCode);
            Assert.AreEqual("VA", entity.Entity.State.Abbreviation);
        }

        private bool ResultsPass(string? first, string? last, string? abbrev, string? city, Domain.Features.Entity.SearchEntitysResult results)
        {
            foreach (var result in results.Results)
            {
                if (!string.IsNullOrEmpty(first) && !result.FirstName.ToUpper().Contains(first.ToUpper()) ||
                    !string.IsNullOrEmpty(last) && !result.LastName.ToUpper().Contains(last.ToUpper()) ||
                    !string.IsNullOrEmpty(abbrev) && !result.Abbreviation.ToUpper().Contains(abbrev.ToUpper()) ||
                    !string.IsNullOrEmpty(city) && !result.City.ToUpper().Contains(city.ToUpper()))
                {
                    System.Diagnostics.Debug.WriteLine($"Result failed: {result}");
                    return false;
                }
            }

            return true;
        }
    }
}
