using AutoMapper;
using BusinessLayer.Interfaces;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto.OtherCollateral
{
    public class OtherCollateral : Collateral.Collateral
    {
        private static IDictionaryService _dictionaryService;

        static OtherCollateral()
        {
            _dictionaryService = ServiceLocator.Current.GetInstance<IDictionaryService>();
        }

        public string Specification { get; set; }

        public static implicit operator OtherCollateral(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<OtherCollateral>(collateral.Body);
        }

        public static implicit operator string(OtherCollateral collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }

        public static explicit operator OtherCollateral(Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            var dto = Mapper.Map<OtherCollateral>(collateral);

            RestoreDictionaryProperties(dto, collateral);

            return dto;
        }

        public static implicit operator Presentation.Responses.OtherCollateral.OtherCollateral(OtherCollateral collateral)
        {
            var response = Mapper.Map<Presentation.Responses.OtherCollateral.OtherCollateral>(collateral);

            return response;
        }

        protected static void RestoreDictionaryProperties(OtherCollateral dto, Models.Presentation.Requests.OtherCollateral.OtherCollateral collateral)
        {
            Collateral.Collateral.RestoreDictionaryProperties(dto, collateral);
        }
    }
}
