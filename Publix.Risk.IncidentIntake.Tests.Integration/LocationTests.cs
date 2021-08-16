using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.UI.Controllers;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    [TestClass]
    public class LocationTests : BaseTest
    {
        private LocationController controller { get; set; }

        [TestInitialize]
        public void SetupCodeTests()
        {
            base.SetupTest();
            if (provider != null)
            {
                controller = new LocationController((ILogger)provider.GetService(typeof(ILogger)), (IConfiguration)provider.GetService(typeof(IConfiguration)), (MediatR.IMediator)provider.GetService(typeof(MediatR.IMediator)));
            }
            else
            {
                Assert.Fail("Service Provider is Null!");
            }
        }

        [TestMethod]
        public void SeachLocationTests()
        {
            string city = "Lakeland";

            var results = controller.GetLocations(null, city, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count == results.PageSize);
            Assert.IsTrue(ResultsPass(null, city, null, results));

            string number = "0357";

            results = controller.GetLocations(number, city, null).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count == 10);
            Assert.IsTrue(ResultsPass(number, city, null, results));

            string state = "FL";

            results = controller.GetLocations(number, city, state).Result;

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count == 10);
            Assert.IsTrue(ResultsPass(number, city, state, results));
        }

        [TestMethod]
        public void GetLocation_OK()
        {
            int id = 47;

            var entity = controller.GetLocationByEntityId(id).Result;

            Assert.IsNotNull(entity);
            Assert.AreEqual("US", entity.Entity.Country.ShortCode);
            Assert.AreEqual(id, entity.Entity.EntityId);
            Assert.AreEqual("Publix", entity.Entity.Parent.LastName);
        }

        private bool ResultsPass(string? number, string? city, string? state, Domain.Features.Entity.SearchLocationsResult results)
        {
            foreach (var result in results.Results)
            {
                if (!string.IsNullOrEmpty(number) && !result.LastName.ToUpper().Contains(number.ToUpper()) ||
                    !string.IsNullOrEmpty(state) && !result.State.Abbreviation.Contains(state.ToUpper()) ||
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
