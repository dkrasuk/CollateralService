using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Responses.Collateral
{ 
    public class Amount
    {
        public Currency Currency { get; set; }
        public double? Value { get; set; }

        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<Amount>();
        }
    }    
}
