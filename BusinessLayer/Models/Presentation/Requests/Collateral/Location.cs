using AutoMapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Requests.Collateral
{
    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public static implicit operator Location(Dto.Collateral.Location location)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Dto.Collateral.Location, Location>());
            return Mapper.Map<Location>(location);
        }
        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<Location>();
        }

    }
}
