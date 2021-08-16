using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    [TestClass]
    public class AssureClaimsAPITests : BaseTest
    {
        [TestMethod]
        public void GetClaimTest()
        {
            IAssureClaimsRepository repo = provider.GetService<IAssureClaimsRepository>();

            Assert.IsNotNull(repo);

            ClaimEntity? claim = repo.GetClaim(551, 424).Result;

            Assert.IsNotNull(claim);
            Assert.IsTrue(claim.ClaimId == 424);

            claim = repo.GetClaim(116, 501).Result;

            Assert.IsNotNull(claim);
            Assert.IsTrue(claim.ClaimId == 501);

            claim = repo.GetClaim(738, 490).Result;

            Assert.IsNotNull(claim);
            Assert.IsTrue(claim.ClaimId == 490);
        }
    }
}
