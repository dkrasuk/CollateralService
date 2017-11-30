using CollateralService.ApiClient.Client;
using Microsoft.Practices.Unity;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CollateralServiceApiClient
{
    public static class Bootstraper
    {
        public static void Register(IUnityContainer container)
        {
            var credentials = new BasicAuthenticationCredentials()
            {
                UserName = ConfigurationManager.AppSettings["CollateralServiceApiLogin"],
                Password = ConfigurationManager.AppSettings["CollateralServiceApiPassword"]
            };
            var baseUri = new Uri(ConfigurationManager.AppSettings["CollateralServiceApiEndpoint"]);

            container.RegisterType<ICollateralServiceWebAPI, CollateralServiceWebAPI>(new InjectionConstructor(baseUri, credentials, new DelegatingHandler[0]));
        }
    }
}
