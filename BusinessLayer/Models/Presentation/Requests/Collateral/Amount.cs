using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Requests.Collateral
{ 
    public class Amount
    {
        public Currency Currency { get; set; }
        public double? Value { get; set; }

        public static implicit operator Amount(Dto.Collateral.Amount collateral)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.Amount, Amount>());
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.Currency, Currency>());           

            return Mapper.Map<Amount>(collateral);
        }

        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<Amount>();
        }
    }
}
