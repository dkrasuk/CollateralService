using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Responses.Collateral
{
    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }

        public void DeserializeJson(JToken iListValue)
        {
            iListValue.ToObject<Location>();
        }
    }
}
