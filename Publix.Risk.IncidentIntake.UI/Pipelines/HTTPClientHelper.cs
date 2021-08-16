using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Pipelines
{
    public class HTTPClientHelper : IHTTPClientHelper
    {
        private readonly IHttpClientFactory httpClientFactory;
        private HttpClient client;
        private readonly String ClientName;

        public HTTPClientHelper(IHttpClientFactory httpClientFactory, string ClientName)
        {
            this.httpClientFactory = httpClientFactory;
            this.ClientName = ClientName;
        }

        #region Generic, Async, static HTTP functions for GET, POST, PUT, and DELETE             

        public async Task<T> GetAsync<T>(string url, Dictionary<string, string> keyValuePairs = null)
        {
            T data;
            using (client = httpClientFactory.CreateClient(ClientName))
            {
                try
                {
                    if (keyValuePairs != null)
                    {
                        url = GenerateUri(url, keyValuePairs).ToString();
                    }
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    using (HttpContent content = response.Content)
                    {
                        string d = await content.ReadAsStringAsync();
                        if (d != null)
                        {
                            data = JsonConvert.DeserializeObject<T>(d);
                            return (T)data;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PostAsync<T>(string url, HttpContent contentPost)
        {
            T data;
            using (client = httpClientFactory.CreateClient(ClientName))
            {
                using (HttpResponseMessage response = await client.PostAsync(url, contentPost))
                using (HttpContent content = response.Content)
                {
                    string d = await content.ReadAsStringAsync();
                    if (d != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(d);
                        return (T)data;
                    }
                }
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PutAsync<T>(string url, HttpContent contentPut)
        {
            T data;
            using (client = httpClientFactory.CreateClient(ClientName))
            {

                using (HttpResponseMessage response = await client.PutAsync(url, contentPut))
                using (HttpContent content = response.Content)
                {
                    string d = await content.ReadAsStringAsync();
                    if (d != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(d);
                        return (T)data;
                    }
                }
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            T newT;
            using (client = httpClientFactory.CreateClient(ClientName))
            {

                using (HttpResponseMessage response = await client.DeleteAsync(url))
                using (HttpContent content = response.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        newT = JsonConvert.DeserializeObject<T>(data);
                        return newT;
                    }
                }
            }
            Object o = new Object();
            return (T)o;
        }

        private Uri GenerateUri(string baseUrl, Dictionary<string, string> keyValuePairs)
        {
            var builder = new UriBuilderExt(baseUrl);
            foreach (var keyValue in keyValuePairs)
            {
                builder.AddParameter(keyValue.Key, keyValue.Value);
            }
            var uri = builder.Uri;
            return uri;
        }
        #endregion
    }
}

