using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Pipelines
{
    public interface IHTTPClientHelper
    {
        Task<T> GetAsync<T>(string url, Dictionary<string, string> keyValuePairs = null);
        Task<T> PostAsync<T>(string url, HttpContent contentPost);
        Task<T> PutAsync<T>(string url, HttpContent contentPut);
        Task<T> DeleteAsync<T>(string url);
    }
}
