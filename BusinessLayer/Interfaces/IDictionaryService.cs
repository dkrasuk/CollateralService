using BusinessLayer.Models.Dto.Car;
using BusinessLayer.Models.Dto.Collateral;
using BusinessLayer.Models.Dto.Mortgage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDictionaryService
    {
        Appointment GetAppointmentById(string id);
        SettlementType GetSettlementTypeById(string id);
        Status GetStatusById(string id);
        Models.Dto.Collateral.Type GetTypeById(string id);
        Subtype GetSubTypeById(string id);
        SaleType GetSaleTypeById(string id);
        BodyType  GetBodyTypeById(string id);
        Brand GetBrandById(string id);
        Color GetColorById(string id);
        GearBox GetGearBoxById(string id);
        IEnumerable<Model> GetModelById(string id, string brandId);
        Source GetSourceById(string name);
        EvalutionType GetEvalutionTypeById(string name);
        Currency GetCurrencyTypeById(string name);
        Moratorium GetMoratoriumById(string id);

        Appointment GetAppointmentByName(string name);
        SettlementType GetSettlementTypeByName(string name);
        Status GetStatusByName(string name);
        Models.Dto.Collateral.Type GetTypeByName(string name);
        Subtype GetSubTypeByName(string name);
        SaleType GetSaleTypeByName(string name);
        BodyType GetBodyTypeByName(string nName);
        Brand GetBrandByName(string name);
        Color GetColorByName(string name);
        GearBox GetGearBoxByName(string name);
        IEnumerable<Model> GetModelByName(string name, string brand);
        Source GetSourceByName(string name);
        EvalutionType GetEvalutionTypeByName(string name);
        Currency GetCurrencyTypeByName(string name);
        Moratorium GetMoratoriumByName(string name);
        State GetStateByName(string name);
        State GetStateById(string id);
        MasterSystem GetMasterSystemByName(string name);
        MasterSystem GetMasterSystemById(string id);
        Currency GetCurrencyTypeByCode(string code);

    }
}
