using BusinessLayer.Interfaces;
using BusinessLayer.Models.Dto.Collateral;
using BusinessLayer.Models.Dto.Mortgage;
using Dictionaries;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.Dto.Car;

namespace BusinessLayer
{
    public class DictionaryService : IDictionaryService
    {
        IDictionaryOperations _dictionaryOperations;

        public DictionaryService(IDictionaryOperations dictionaryoperations)
        {
            _dictionaryOperations = dictionaryoperations;
        }


        /// <summary>
        /// Gets the item by identifier.
        /// </summary>
        /// <param name="dictionaryName">Name of the dictionary.</param>
        /// <param name="version">The version.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private async Task<JObject> GetItemById(string dictionaryName, string version, string id)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync(dictionaryName, version);
            return (dictionary.Items.SingleOrDefault(i => i.ValueId == id).Value as JObject);
        }

        /// <summary>
        /// Gets the Source by identifier asynchronous.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Source> GetSourceByIdAsync(string id)
        {
            var item = await GetItemById("EvaluationSource", "1", id);
            return item.ToObject<Source>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Currency> GetCurrencyByIdAsync(string id)
        {
            var item = await GetItemById("CurrencyType", "1", id);
            return item.ToObject<Currency>();
        }
        public async Task<Currency> GetCurrencyByCodeAsync(string code)
        {

            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CurrencyType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Currency>()).SingleOrDefault(s => s.Code.ToLower() == code.ToLower());

        }
        /// <summary>
        /// Gets the EvalutionType by identifier asynchronous.   
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EvalutionType> GetEvalutionTypeByIdAsync(string id)
        {
            var item = await GetItemById("EvaluationTypes", "1", id);
            return item.ToObject<EvalutionType>();
        }
        /// <summary>
        /// Gets the Appointment by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentByIdAsync(string id)
        {
            var item = await GetItemById("CollateralAppointment", "1", id);
            return item.ToObject<Appointment>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SettlementType> GetSettlementTypeByIdAsync(string id)
        {
            var item = await GetItemById("CollateralSettlementType", "1", id);
            return item.ToObject<SettlementType>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Status> GetStatusByIdAsync(string id)
        {
            var item = await GetItemById("CollateralStatus", "1", id);
            return item.ToObject<Status>();
        }

        /// <summary>
        /// Gets the type by identifier.
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        public async Task<Models.Dto.Collateral.Type> GetTypeByIdAsync(string id)
        {
            var item = await GetItemById("CollateralType", "1", id);
            return item.ToObject<Models.Dto.Collateral.Type>();
        }

        /// <summary>
        /// Gets the Sub Type by identifier.
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        public async Task<Subtype> GetSubTypeByIdAsync(string id)
        {
            var item = await GetItemById("CollateralSubType", "1", id);
            return item.ToObject<Subtype>();
        }

        /// <summary>
        /// Gets the Sale Type by identifier.
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        public async Task<SaleType> GetSaleTypeByIdAsync(string id)
        {
            var item = await GetItemById("CollateralSaleType", "1", id);
            return item.ToObject<SaleType>();
        }

        /// <summary>
        /// Gets the Body Type by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BodyType> GetBodyTypeByIdAsync(string id)
        {
            var item = await GetItemById("CollateralCarBodyType", "1", id);
            return item.ToObject<BodyType>();
        }

        /// <summary>
        /// Gets the Brand by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Brand> GetBrandByIdAsync(string id)
        {
            var item = await GetItemById("CollateralCarBrand", "1", id);
            return item.ToObject<Brand>();
        }

        /// <summary>
        /// Gets the Color by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Color> GetColorByIdAsync(string id)
        {
            var item = await GetItemById("CollateralCarColor", "1", id);
            return item.ToObject<Color>();
        }

        /// <summary>
        /// Gets the GearBox by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GearBox> GetGearBoxByIdAsync(string id)
        {
            var item = await GetItemById("CollateralCarGearBox", "1", id);
            return item.ToObject<GearBox>();
        }

        /// <summary>
        /// Gets the Model by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Model>> GetModelByIdAsync(string id, string brandId)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralCarModel", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Model>()).Where(s => (s.Id == id) && (s.Brand == brandId || string.IsNullOrEmpty(brandId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private async Task<Moratorium> GetMoratoriumByidAsync(string id)
        {
            var item = await GetItemById("CollateralMoratorium", "1", id);
            return item.ToObject<Moratorium>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private async Task<State> GetStateByIdAsync(string id)
        {
            var item = await GetItemById("CollateralStates", "1", id);
            return item.ToObject<State>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<MasterSystem> GetMasterSystemByIdAsync(string id)
        {
            var item = await GetItemById("MasterSystems", "1", id);
            return item.ToObject<MasterSystem>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MasterSystem GetMasterSystemById(string id)
        {
            return Task.Factory.StartNew(() => GetMasterSystemByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Source GetSourceById(string id)
        {
            return Task.Factory.StartNew(() => GetSourceByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EvalutionType GetEvalutionTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetEvalutionTypeByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        //GetCurrencyByIdAsync
        public Currency GetCurrencyTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetCurrencyByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the appointment type by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Appointment GetAppointmentById(string id)
        {
            return Task.Factory.StartNew(() => GetAppointmentByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the SettlementType by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SettlementType GetSettlementTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetSettlementTypeByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the Status by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Status GetStatusById(string id)
        {
            return Task.Factory.StartNew(() => GetStatusByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.Dto.Collateral.Type GetTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetTypeByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public Subtype GetSubTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetSubTypeByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public SaleType GetSaleTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetSaleTypeByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public BodyType GetBodyTypeById(string id)
        {
            return Task.Factory.StartNew(() => GetBodyTypeByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public Brand GetBrandById(string id)
        {
            return Task.Factory.StartNew(() => GetBrandByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public Color GetColorById(string id)
        {
            return Task.Factory.StartNew(() => GetColorByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public GearBox GetGearBoxById(string id)
        {
            return Task.Factory.StartNew(() => GetGearBoxByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        public IEnumerable<Model> GetModelById(string id, string brandId)
        {
            return Task.Factory.StartNew(() => GetModelByIdAsync(id, brandId)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Moratorium GetMoratoriumById(string id)
        {
            return Task.Factory.StartNew(() => GetMoratoriumByidAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public State GetStateById(string id)
        {
            return Task.Factory.StartNew(() => GetStateByIdAsync(id)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Source> GetSourceByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("EvaluationSource", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Source>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<EvalutionType> GetEvalutionTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("EvaluationTypes", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<EvalutionType>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Currency> GetCurrencyTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CurrencyType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Currency>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Appointment by identifier asynchronous.
        /// </summary>
        /// <param name="name">The identifier.</param>
        /// <returns></returns>
        public async Task<Appointment> GetAppointmentByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralAppointment", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Appointment>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SettlementType> GetSettlementTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralSettlementType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<SettlementType>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Status> GetStatusByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralStatus", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Status>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the type by identifier.
        /// </summary>
        /// <param name="name">identifier</param>
        /// <returns></returns>
        public async Task<Models.Dto.Collateral.Type> GetTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Models.Dto.Collateral.Type>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Sub Type by identifier.
        /// </summary>
        /// <param name="name">identifier</param>
        /// <returns></returns>
        public async Task<Subtype> GetSubTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralSubType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Subtype>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Sale Type by identifier.
        /// </summary>
        /// <param name="name">identifier</param>
        /// <returns></returns>
        public async Task<SaleType> GetSaleTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralSaleType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<SaleType>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Body Type by identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<BodyType> GetBodyTypeByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralCarBodyType", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<BodyType>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Brand by identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Brand> GetBrandByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralCarBrand", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Brand>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Color by identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Color> GetColorByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralCarColor", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Color>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the GearBox by identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<GearBox> GetGearBoxByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralCarGearBox", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<GearBox>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets the Model by identifier.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Model>> GetModelByNameAsync(string name, string brand)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralCarModel", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Model>()).Where(s => (s.Name.ToLower() == name.ToLower()) && (s.Brand == brand || string.IsNullOrEmpty(brand)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<State> GetStateByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralStates", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<State>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Gets Moratorium dictionary by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<Moratorium> GetMoratoriumByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("CollateralMoratorium", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<Moratorium>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<MasterSystem> GetMasterSystemByNameAsync(string name)
        {
            var dictionary = await _dictionaryOperations.GetDictionaryByNameAndVersionAsync("MasterSystems", "1");
            return dictionary.Items.Select(i => (i.Value as JObject).ToObject<MasterSystem>()).SingleOrDefault(s => s.Name.ToLower() == name.ToLower());
        }



        /// <summary>
        ///     
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Source GetSourceByName(string name)
        {
            return Task.Factory.StartNew(() => GetSourceByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EvalutionType GetEvalutionTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetEvalutionTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Currency GetCurrencyTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetCurrencyTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the appointment type by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Appointment GetAppointmentByName(string name)
        {
            return Task.Factory.StartNew(() => GetAppointmentByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the SettlementType by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SettlementType GetSettlementTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetSettlementTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets the Status by identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Status GetStatusByName(string name)
        {
            return Task.Factory.StartNew(() => GetStatusByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Models.Dto.Collateral.Type GetTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Subtype GetSubTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetSubTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SaleType GetSaleTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetSaleTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BodyType GetBodyTypeByName(string name)
        {
            return Task.Factory.StartNew(() => GetBodyTypeByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Brand GetBrandByName(string name)
        {
            return Task.Factory.StartNew(() => GetBrandByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Color GetColorByName(string name)
        {
            return Task.Factory.StartNew(() => GetColorByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GearBox GetGearBoxByName(string name)
        {
            return Task.Factory.StartNew(() => GetGearBoxByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Model> GetModelByName(string name, string brand)
        {
            return Task.Factory.StartNew(() => GetModelByNameAsync(name, brand)).Unwrap().GetAwaiter().GetResult();
        }

        public Moratorium GetMoratoriumByName(string name)
        {
            return Task.Factory.StartNew(() => GetMoratoriumByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public State GetStateByName(string name)
        {
            return Task.Factory.StartNew(() => GetStateByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MasterSystem GetMasterSystemByName(string name)
        {
            return Task.Factory.StartNew(() => GetMasterSystemByNameAsync(name)).Unwrap().GetAwaiter().GetResult();
        }

        public Currency GetCurrencyTypeByCode(string code)
        {
            return Task.Factory.StartNew(() => GetCurrencyByCodeAsync(code)).Unwrap().GetAwaiter().GetResult();
        }
    }
}
