using AutoMapper;
using BusinessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto.Collateral
{
    public class Evaluation
    {
        private static IDictionaryService _dictionaryService;
        private string id;

        static Evaluation()
        {
            _dictionaryService = ServiceLocator.Current.GetInstance<IDictionaryService>();
        }

        public string Id
        {
            get
            {
                return (string.IsNullOrEmpty(id)? (id = Guid.NewGuid().ToString()) : id);
            }
            set
            {
                id = value;
            }
        }
        public Amount Value { get; set; }
        public DateTime Date { get; set; }
        public Source Source { get; set; }
        public string Responsible { get; set; }
        public DateTime DateEntry { get; set; }
        public EvalutionType Type { get; set; }

        public static implicit operator Evaluation(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<Evaluation>(collateral.Body);
        }


        public static implicit operator Presentation.Responses.Collateral.Evaluation(Evaluation collateral)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Evaluation, Presentation.Responses.Collateral.Evaluation>();
                cfg.CreateMap<Amount, Presentation.Responses.Collateral.Amount>();
                cfg.CreateMap<Source, Presentation.Responses.Collateral.Source>();
                cfg.CreateMap<EvalutionType, Presentation.Responses.Collateral.EvalutionType>();
            }
            );
            return Mapper.Map<Presentation.Responses.Collateral.Evaluation>(collateral);
        }

        public static explicit operator Evaluation(Presentation.Requests.Collateral.Evaluation collateral)
        {
            var dto = Mapper.Map<Evaluation>(collateral);


            if (collateral.Source != null)
            {
                if (collateral.Source.Name == null && collateral.Source.Id != null)
                    dto.Source = _dictionaryService.GetSourceById(collateral.Source.Id);

                if (collateral.Source.Name != null && collateral.Source.Id == null)
                    dto.Source = _dictionaryService.GetSourceByName(collateral.Source.Name);
            }

            if (collateral.Type != null)
            {
                if (collateral.Type.Name == null && collateral.Type.Id != null)
                    dto.Type = _dictionaryService.GetEvalutionTypeById(collateral.Type.Id);

                if (collateral.Type.Name != null && collateral.Type.Id == null)
                    dto.Type = _dictionaryService.GetEvalutionTypeByName(collateral.Type.Name);
            }

            if (collateral.Value.Currency != null)
            {
                if (collateral.Value.Currency.Name == null && collateral.Value.Currency.Id != null)
                    dto.Value.Currency = _dictionaryService.GetCurrencyTypeById(collateral.Value.Currency.Id);

                if (collateral.Value.Currency.Name != null && collateral.Value.Currency.Id == null)
                    dto.Value.Currency = _dictionaryService.GetCurrencyTypeByName(collateral.Value.Currency.Name);

                if (collateral.Value.Currency.Code != null)
                {
                    dto.Value.Currency = _dictionaryService.GetCurrencyTypeByCode(collateral.Value.Currency.Code);
                }
            }

            return dto;

        }


        public static implicit operator string(Evaluation collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }

    }
}