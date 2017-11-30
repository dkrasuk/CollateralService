using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Models.Dto.Collateral
{
    public class Location
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Lat { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Lng { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string Type { get; set; }


        public static implicit operator Location(Entities.Models.Collateral collateral)
        {
            return JsonConvert.DeserializeObject<Location>(collateral.Location);
        }

        public static implicit operator string(Location collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }


        public static implicit operator Presentation.Responses.Collateral.Location(Location collateral)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Location, Presentation.Responses.Collateral.Location>();                
            }
            );
            return Mapper.Map<Presentation.Responses.Collateral.Location>(collateral);
        }


        public static explicit operator Location(Presentation.Requests.Collateral.Location collateral)
        {
            var dto = Mapper.Map<Location>(collateral);            
            return dto;
        }  
    }
}
