using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Publix.Risk.IncidentIntake.Test.Core.Integration
{
    public class BaseIntegrationTest
    {
        protected TestServer Server { get; }
        protected TestServer ProductSearchServer { get; }
        protected HttpClient HttpClient { get; }


        public BaseIntegrationTest()
        {
            //get path to appsettings file, assembly location
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string projectPath = Path.GetDirectoryName(path);

            Server = new TestServer(new WebHostBuilder().UseStartup<Publix.Risk.IncidentIntake.UI.Startup>());
            HttpClient = Server.CreateClient();
        }


        internal string GetRandomText(int seed)
        {
            Random rnd = new Random(seed);
            StringBuilder text = new StringBuilder();

            int val = rnd.Next(0, 8);

            for (int i = 0; i < val; i++)
            {
                int len = rnd.Next(0, 8);

                if (len > 0)
                {
                    for (int j = 1; j <= len; j++)
                    {
                        text.Append(Char.ConvertFromUtf32(rnd.Next(65, 122)));
                    }
                }
                else
                {
                    text.Append(" ");
                }
            }

            return text.ToString();
        }
    }
}
