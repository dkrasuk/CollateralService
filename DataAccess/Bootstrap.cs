using AlfaBank.AlfaCollection.Services.PersonService.DataAccess.Interface;
using Microsoft.Practices.Unity;

namespace AlfaBank.AlfaCollection.Services.PersonService.DataAccess
{
    public static class Bootstrap
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IPersonDataAccessFactory, PersonDataAccessFactory>();
        }
    }
}
