using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Presentation.Responses.OtherCollateral
{
    public class OtherCollateral : Collateral.Collateral
    {
        public string Specification { get; set; }

        public void DeserializeJson(JToken responseDoc)
        {
            responseDoc.ToObject<OtherCollateral>();
        }
    }
}
