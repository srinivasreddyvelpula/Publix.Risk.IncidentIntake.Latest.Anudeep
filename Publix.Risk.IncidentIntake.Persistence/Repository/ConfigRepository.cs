using Microsoft.Extensions.Configuration;
using Publix.Risk.IncidentIntake.Domain.Interfaces;


namespace Publix.Risk.IncidentIntake.Persistence.Repository
{
    public class ConfigRepository : IConfiguration
    {
        public string AC_API_URL { get; }

        public string RMX_DB_CONNECTION { get; }

        public string RMXSecurity_DB_CONNECTION { get; }

        public string PBX_DB_CONNECTION { get; }

        public int LoginWindowLength { get; }

        public string LogLevel { get; }
        public string SendMail_From { get; set; }
        public string Graph_API_Endpoint { get; set; }
        public int MaxItemsReturned { get; set; }
        public string APIKey { get; set; }
        public string FileServerAttachementPath { get; set; }
        public string Environment { get; set; }

        public ConfigRepository(IConfiguration rootConfig)
        {
            AC_API_URL = rootConfig["API_URL"];
            RMX_DB_CONNECTION = rootConfig["RMX_ConnectionString"];
            RMXSecurity_DB_CONNECTION = rootConfig["RMXSecurity_ConnectionString"];
            PBX_DB_CONNECTION = rootConfig["PBX_ConnectionString"];
            LoginWindowLength = int.Parse(rootConfig["Login_Window_Length"] ?? "4");
            LogLevel = rootConfig["LogLevel"] ?? "Info";
            Graph_API_Endpoint = rootConfig["GraphAPI_Endpoint"] ?? "";
            APIKey = rootConfig["API_KEY"] ?? "";
            Environment = System.Environment.GetEnvironmentVariable("PublixEnvironment") ?? "Development";

            FileServerAttachementPath = rootConfig["FileServerAttachementPath"] ?? $"\\\\{Environment.Substring(0, 1)}RMXFS01\\Attachments";

#if DEBUG
            SendMail_From = rootConfig["SendMail_From"] ?? "mark.curtis2@publix.com";
            MaxItemsReturned = 100;
#else
            SendMail_From = rootConfig["SendMail_From"] ?? "IS-RiskMgmtSupport@publix.com";
            MaxItemsReturned = int.Parse(rootConfig["Max_Items_Returned"] ?? "1000");
#endif
        }
    }
}
