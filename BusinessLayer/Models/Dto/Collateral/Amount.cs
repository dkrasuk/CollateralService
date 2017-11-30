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
    public class Amount
    {
        private static IDictionaryService _dictionaryService;

        static Amount()
        {
            _dictionaryService = ServiceLocator.Current.GetInstance<IDictionaryService>();
        }

        public Currency Currency {get;set;}
        public double? Value { get; set; }


        public static implicit operator Amount(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<Amount>(collateral.Body);
        }

        public static implicit operator Presentation.Responses.Collateral.Amount(Amount collateral)
        {
            Mapper.Initialize(cfg =>
            {           
                cfg.CreateMap<Amount, Presentation.Responses.Collateral.Amount>();
                cfg.CreateMap<Models.Dto.Collateral.Currency, Presentation.Responses.Collateral.Currency>();              
            }
            );
            return Mapper.Map<Presentation.Responses.Collateral.Amount>(collateral);
        }
        public static explicit operator Amount(Presentation.Requests.Collateral.Amount collateral)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Presentation.Requests.Collateral.Amount, Amount>();
                cfg.CreateMap<Presentation.Requests.Collateral.Currency, Currency>();  
            });

            var dto = Mapper.Map<Amount>(collateral);

            if (collateral.Currency != null)
            {
                if (collateral.Currency != null && collateral.Currency.Id == null)
                    dto.Currency = _dictionaryService.GetCurrencyTypeById(collateral.Currency.Id);

                if (collateral.Currency != null && collateral.Currency.Id == null)
                    dto.Currency = _dictionaryService.GetCurrencyTypeByName(collateral.Currency.Name);
            }
            return dto;
        }
    }
}
