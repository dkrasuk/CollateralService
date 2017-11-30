using Entities;
using AlfaCollection.Common.Interface;
using AlfaCollection.Common.Services;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.UnitOfWork;


namespace WebAPI
{
    internal static class Bootstraper
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void Register(IUnityContainer container)
        {
            Logger.Bootstraper.Register(container);

            AlfaCollection.Common.Bootstrapper.Register(container);
            GoogleMapService.BusinessLayer.Bootstraper.Register(container);

            BusinessLayer.Bootstrap.Register(container);

            container
                .RegisterType<IAccountService, AccountService>(new InjectionConstructor(AppSettings.HrApiEndpoint))
                .RegisterType<IDataContextAsync, Context>(new PerRequestLifetimeManager())
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());
        }
    }
}