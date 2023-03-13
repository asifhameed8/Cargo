using Cargo.Core.Repositories;
using Cargo.Models.ViewModel;
using Cargo.Service.HttpClientSrv;
using Cargo.Service.QuotesSrv;
using Cargo.Service.UOW;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Cargo.Service.QuotesSrv.QuotesServices;

namespace Cargo.Service.QuotesSrv
{
    public class QuotesServices : IQuotesServices
    {
        private readonly IApiHttpClient _apiHttpClient;
        private readonly ILogger<QuotesServices> _logger;

        public QuotesServices(IApiHttpClient apiHttpClient, ILogger<QuotesServices> logger)
        {
            _apiHttpClient = apiHttpClient;
            _logger = logger;
        }


        public async Task<ListAuthorDetailsVM> GetAllAuthor(string AuthorName, int Limit, string Filds)
        {
            try
            {
                string query = $"quotes?author={AuthorName}&fields={Filds}&limit={Limit}";
                var result = _apiHttpClient.Get_Request(query).Result;
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ListAuthorDetailsVM>(result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    var _readErrors = await result.Content.ReadAsStringAsync();

                    throw new Exception(_readErrors);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<QuotesDetailsVM> GetRandomQuotes()
        {
            try
            {
                var result = _apiHttpClient.Get_Request("quotes/random").Result;
                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<QuotesDetailsVM>>(await result.Content.ReadAsStringAsync()).FirstOrDefault();
                }
                else
                {
                    var _readErrors = await result.Content.ReadAsStringAsync();

                    throw new Exception(_readErrors);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
