using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Cargo.Service.HttpClientSrv
{
    public class ApiHttpClient : IApiHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration iconfiguration;
        private string BaseUrl = string.Empty;
        public ApiHttpClient(IConfiguration iconfiguration, IHttpClientFactory httpClientFactory)
        {
            this.iconfiguration = iconfiguration;
            _httpClientFactory = httpClientFactory;
            BaseUrl = this.iconfiguration.GetValue<string>("Api:BaseUrl");
        }
        public async Task<HttpResponseMessage> Get_Request(string requestUrl)
        {
            try
            {
                requestUrl = string.Concat(BaseUrl, requestUrl);
                using (HttpClient client = _httpClientFactory.CreateClient())
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    return await client.SendAsync(request);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
