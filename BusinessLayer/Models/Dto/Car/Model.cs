using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models.Dto.Car
{
    public class Model : Dictionary
    { 
        public string Brand { get; set; }
    }
}