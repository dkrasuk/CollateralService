using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using AlfaCollection.Common;
using WebApi.Filters;

namespace WebAPI
{
    /// <summary>
    /// Class WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            RegisterDependencyResolver(config);

            config.MapHttpAttributeRoutes();
            config.Filters.Add(new CustomExceptionFilter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{action}",
                defaults: new { controller = "person" }
            );
        }

        /// <summary>
        /// Registers the dependency resolver.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void RegisterDependencyResolver(HttpConfiguration config)
        {
            var container = new UnityContainer();
            Bootstraper.Register(container);

            config.DependencyResolver = new UnityResolver(container);

            var locator = new UnityServiceLocator(container);

            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
