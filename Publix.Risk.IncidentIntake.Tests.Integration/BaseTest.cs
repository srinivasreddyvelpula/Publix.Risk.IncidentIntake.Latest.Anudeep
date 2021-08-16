using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Publix.Risk.IncidentIntake.UI;
using System;

namespace Publix.Risk.IncidentIntake.Tests.Integration
{
    public class BaseTest
    {
        public IServiceProvider? provider { get; set; }


        [TestInitialize]
        public void SetupTest()
        {
            IConfigurationRoot mstestConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var host = new WebHostBuilder().UseConfiguration(mstestConfiguration).UseStartup<Startup>();

            provider = host.Build().Services;
        }


    }
}
