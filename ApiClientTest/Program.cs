using CollateralService.ApiClient.Client;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var credentials = new BasicAuthenticationCredentials();
            credentials.UserName = "login";
            credentials.Password = "pass!";

            var baseUri = new Uri("http://localhost:8080");
            var _webApi = new CollateralServiceWebAPI(baseUri, credentials, new DelegatingHandler[0]);
            var task = _webApi.CollateralAgreements.GetCollateralByCollateralAgreementWithHttpMessagesAsync("123");
            task.Wait();
            var res = task.Result;
        }
    }
}
