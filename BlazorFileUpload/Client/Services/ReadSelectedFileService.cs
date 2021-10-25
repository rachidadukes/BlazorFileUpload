
using BlazorFileUpload.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorFileUpload.Client.Services
{
    public class ReadSelectedFileService : IReadSelectedFileService
    {
        private readonly HttpClient httpClient;

        public ReadSelectedFileService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> ReadSelectedFile(string strFile)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"api/ReadSelectedFile/{strFile}");
        }

     



    }
}

