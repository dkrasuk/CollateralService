using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto.Collateral
{
    public class History
    {
        public IEnumerable<Collateral> CollateralHistory { get; set; }

        public static implicit operator string(History collateral)
        {
            return JsonConvert.SerializeObject(collateral);
        }
    }
}
