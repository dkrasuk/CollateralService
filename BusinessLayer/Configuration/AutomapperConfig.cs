using AutoMapper;
using BusinessLayer.Models.Dto.Collateral;
using BusinessLayer.Models.Dto.Car;
using BusinessLayer.Models.Dto.CollateralAgreement;
using BusinessLayer.Models.Dto.Mortgage;

namespace BusinessLayer
{
    public static class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                #region Collateral
                cfg.CreateMap<Collateral, Models.Presentation.Responses.Collateral.Collateral>();
                cfg.CreateMap<Amount, Models.Presentation.Responses.Collateral.Amount>();
                cfg.CreateMap<Currency, Models.Presentation.Responses.Collateral.Currency>();
                cfg.CreateMap<Evaluation, Models.Presentation.Responses.Collateral.Evaluation>();
                cfg.CreateMap<EvalutionType, Models.Presentation.Responses.Collateral.EvalutionType>();
                cfg.CreateMap<SaleType, Models.Presentation.Responses.Collateral.SaleType>();
                cfg.CreateMap<Source, Models.Presentation.Responses.Collateral.Source>();
                cfg.CreateMap<Status, Models.Presentation.Responses.Collateral.Status>();
                cfg.CreateMap<Subtype, Models.Presentation.Responses.Collateral.Subtype>();
                cfg.CreateMap<Type, Models.Presentation.Responses.Collateral.Type>();
                cfg.CreateMap<Moratorium, Models.Presentation.Responses.Collateral.Moratorium>();
                cfg.CreateMap<State, Models.Presentation.Responses.Collateral.State>();
                cfg.CreateMap<MasterSystem, Models.Presentation.Responses.Collateral.MasterSystem>();


                cfg.CreateMap<Models.Presentation.Requests.Collateral.Collateral, Collateral>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Type, Type>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Amount, Amount>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Currency, Currency>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Evaluation, Evaluation>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.EvalutionType, EvalutionType>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.SaleType, SaleType>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Source, Source>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Status, Status>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Subtype, Subtype>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Moratorium, Moratorium>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.State, State>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.MasterSystem, MasterSystem>();
                #endregion

                #region Car
                cfg.CreateMap<Models.Presentation.Requests.Car.Car, Car>();
                cfg.CreateMap<Models.Presentation.Requests.Car.BodyType, BodyType>();
                cfg.CreateMap<Models.Presentation.Requests.Car.Brand, Brand>();
                cfg.CreateMap<Models.Presentation.Requests.Car.Color, Color>();
                cfg.CreateMap<Models.Presentation.Requests.Car.GearBox, GearBox>();
                cfg.CreateMap<Models.Presentation.Requests.Car.Model, Model>();
                cfg.CreateMap<Models.Presentation.Requests.Car.Region, Models.Dto.Car.Region>();

                cfg.CreateMap<Car, Models.Presentation.Responses.Car.Car>();
                cfg.CreateMap<BodyType, Models.Presentation.Responses.Car.BodyType>();
                cfg.CreateMap<Brand, Models.Presentation.Responses.Car.Brand>();
                cfg.CreateMap<Color, Models.Presentation.Responses.Car.Color>();
                cfg.CreateMap<GearBox, Models.Presentation.Responses.Car.GearBox>();
                cfg.CreateMap<Model, Models.Presentation.Responses.Car.Model>();
                cfg.CreateMap<Models.Dto.Car.Region, Models.Presentation.Responses.Car.Region>();
                #endregion

                #region CollateralAgreement
                cfg.CreateMap<Entities.Models.CollateralAgreement, CollateralAgreement>();
                cfg.CreateMap<CollateralAgreement, Models.Presentation.Responses.CollateralAgreement.CollateralAgreement>();
                #endregion

                #region Mortgage
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.Mortgage, Mortgage>();
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.StreetType, StreetType>();
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.SettlementType, SettlementType>();
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.Settlement, Settlement>();
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.Appointment, Appointment>();
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.District, District>();
                cfg.CreateMap<Models.Presentation.Requests.Mortgage.Region, Models.Dto.Mortgage.Region>();
                cfg.CreateMap<Mortgage, Models.Presentation.Responses.Mortgage.Mortgage>();
                cfg.CreateMap<StreetType, Models.Presentation.Responses.Mortgage.StreetType>();
                cfg.CreateMap<SettlementType, Models.Presentation.Responses.Mortgage.SettlementType>();
                cfg.CreateMap<Settlement, Models.Presentation.Responses.Mortgage.Settlement>();
                cfg.CreateMap<Appointment, Models.Presentation.Responses.Mortgage.Appointment>();
                cfg.CreateMap<District, Models.Presentation.Responses.Mortgage.District>();
                cfg.CreateMap<Models.Dto.Mortgage.Region, Models.Presentation.Responses.Mortgage.Region>();
                #endregion

                #region OtherCollateral
                cfg.CreateMap<Models.Presentation.Requests.OtherCollateral.OtherCollateral, Models.Dto.OtherCollateral.OtherCollateral>();
                cfg.CreateMap<Models.Dto.OtherCollateral.OtherCollateral, Models.Presentation.Responses.OtherCollateral.OtherCollateral>();
                #endregion

                #region Evaluation
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Evaluation, Evaluation>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Amount, Amount>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Source, Source>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.EvalutionType, EvalutionType>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Amount, Amount>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Currency, Currency>();
                #endregion

                #region Location
                cfg.CreateMap<Location, Models.Presentation.Responses.Collateral.Location>();
                cfg.CreateMap<Models.Presentation.Requests.Collateral.Location, Location>();               
                #endregion
            });
        }
    }
}
