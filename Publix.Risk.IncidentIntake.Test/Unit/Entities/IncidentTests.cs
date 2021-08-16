using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publix.Risk.IncidentIntake.Test.Core.Unit.Entities
{
    [TestClass]
    public class IncidentTests
    {
        [TestMethod]
        public void Incident_CTOR_OK()
        {
            Incident incident = new Incident();

            Assert.IsNotNull(incident.Data);
        }
    }
}
