using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestProject.Services
{
    public sealed class NetwrokService : HttpClient
    {
        private static readonly NetwrokService instance = new NetwrokService();
        public static NetwrokService Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<string> GetRequestResultAsync(string url)
        {
            var urlContents = await GetAsync(url, HttpCompletionOption.ResponseContentRead);
            if (urlContents.IsSuccessStatusCode)
                return await urlContents.Content.ReadAsStringAsync();
                        
            return String.Empty;
        }

        static NetwrokService() { }
        private NetwrokService() { }

    }
}