using Newtonsoft.Json.Serialization;
using System;

namespace Publix.Risk.IncidentIntake.UI
{
    internal class MyCustomContractResolver : IContractResolver
    {
        public CamelCaseNamingStrategy NamingStrategy { get; set; }

        public JsonContract ResolveContract(Type type)
        {
            throw new NotImplementedException();
        }
    }
}