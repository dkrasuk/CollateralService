
using BusinessLayer.Interfaces;
using Microsoft.Practices.Unity;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;

namespace BusinessLayer
{
    public static class Bootstrap
    {
        public static void Register(IUnityContainer container)
        {
            DictionariesClient.Bootsrap.Register(container);

            container
                .RegisterType<IRepositoryAsync<Entities.Models.Collateral>, Repository<Entities.Models.Collateral>>()
                .RegisterType<IRepositoryAsync<Entities.Models.CollateralAgreement>, Repository<Entities.Models.CollateralAgreement>>()
                .RegisterType<IRepositoryAsync<Entities.Models.CreditAgreement>, Repository<Entities.Models.CreditAgreement>>()
                .RegisterType<ICollateralService, CollateralService>()
                .RegisterType<ICollateralAgreementService, CollateralAgreementService>()
                .RegisterType<IDictionaryService, DictionaryService>()
                .RegisterType<ICreditAgreementService, CreditAgreementService>();

            AutomapperConfig.RegisterMappings();
        }
    }
}
