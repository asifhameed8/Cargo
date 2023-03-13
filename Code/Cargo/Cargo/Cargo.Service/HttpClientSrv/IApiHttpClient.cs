using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Service.HttpClientSrv
{
    public interface IApiHttpClient
    {
        Task<HttpResponseMessage> Get_Request(string requestUrl);
    }
}
